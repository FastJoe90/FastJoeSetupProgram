using System.Linq;

/// <summary>
/// Represents a shock absorber setting with compression and rebound.
/// Rebound can be adjusted in discrete "clicks" (steps).
/// This class also contains valving specification data used to compute
/// damping at representative velocities (1 ips and 3 ips for rebound,
/// 3 ips for compression). All valving data lives inside this class.
/// </summary>
public class Shock
{
    /// <summary>Base rebound value (legacy numeric base, not used when valving table present)</summary>
    public float ReboundBase { get; set; }

    /// <summary>Compression setting (user-facing continuous value).</summary>
    public float Compression { get; set; }

    /// <summary>Maximum number of negative rebound clicks supported.
    /// ReboundClicks ranges from -MaxNegativeClicks .. 0 where 0 = FULL STIFF and -MaxNegativeClicks = FULL SOFT.</summary>
    public int MaxNegativeClicks { get; init; } = 26;

    private int _reboundClicks;

    /// <summary>
    /// Number of rebound clicks (-MaxNegativeClicks .. 0). 0 = FULL STIFF, -MaxNegativeClicks = FULL SOFT.
    /// Default is 0.
    /// </summary>
    public int ReboundClicks
    {
        get => _reboundClicks;
        set => _reboundClicks = Clamp(value, -MaxNegativeClicks, 0);
    }

    /// <summary>
    /// Legacy per-click numeric multiplier (kept for compatibility).
    /// </summary>
    public float ReboundPerClick { get; set; } = 0.5f;

    /// <summary>
    /// Computed numeric rebound value using base + clicks * per-click (fallback).
    /// When detailed valving tables are set, use GetReboundForVelocity.
    /// </summary>
    public float Rebound => ReboundBase + (_reboundClicks * ReboundPerClick);

    // --- Valving specification (all arrays length MaxNegativeClicks+1). ---
    // Rebound damping measured at 1 ips for each click position (index 0 -> 0 clicks (full stiff), index N -> full soft)
    private float[] _reboundAt1ips;
    // Rebound damping measured at 3 ips for each click position
    private float[] _reboundAt3ips;
    // Compression damping measured at 3 ips for each click position (some shocks tune compression by click)
    private float[] _compressionAt3ips;

    public Shock()
    {
        // default to 0 clicks
        _reboundClicks = 0;
        EnsureValvingArrays();
    }

    public Shock(float compression, float reboundBase, int initialClicks = 0, float reboundPerClick = 0.5f, int maxNegativeClicks = 26)
    {
        Compression = compression;
        ReboundBase = reboundBase;
        ReboundPerClick = reboundPerClick;
        MaxNegativeClicks = maxNegativeClicks;
        _reboundClicks = Clamp(initialClicks, -MaxNegativeClicks, 0);
        EnsureValvingArrays();
    }

    private void EnsureValvingArrays()
    {
        int len = MaxNegativeClicks + 1;
        if (_reboundAt1ips == null || _reboundAt1ips.Length != len) _reboundAt1ips = new float[len];
        if (_reboundAt3ips == null || _reboundAt3ips.Length != len) _reboundAt3ips = new float[len];
        if (_compressionAt3ips == null || _compressionAt3ips.Length != len) _compressionAt3ips = new float[len];
    }

    /// <summary>
    /// Replace valving tables. Arrays must be length MaxNegativeClicks+1.
    /// Values represent damping coefficients (arbitrary units consistent across table).
    /// Index 0 = 0 clicks (full stiff), index MaxNegativeClicks = full soft.
    /// This method will auto-normalize input arrays (pad or truncate) instead of throwing.
    /// </summary>
    public void SetValvingTables(float[] compressionAt3ips, float[] reboundAt1ips, float[] reboundAt3ips)
    {
        if (compressionAt3ips == null || reboundAt1ips == null || reboundAt3ips == null)
            throw new System.ArgumentNullException(nameof(compressionAt3ips));

        int expected = MaxNegativeClicks + 1;
        _compressionAt3ips = NormalizeArray(compressionAt3ips, expected);
        _reboundAt1ips = NormalizeArray(reboundAt1ips, expected);
        _reboundAt3ips = NormalizeArray(reboundAt3ips, expected);
    }

    // Ensure arrays are the expected length by truncating or padding with the last value
    private static float[] NormalizeArray(float[] src, int expected)
    {
        if (src == null) return new float[expected];
        if (src.Length == expected) return (float[])src.Clone();
        var dst = new float[expected];
        int copy = System.Math.Min(src.Length, expected);
        for (int i = 0; i < copy; i++) dst[i] = src[i];
        float padValue = (copy > 0) ? src[copy - 1] : 0f;
        for (int i = copy; i < expected; i++) dst[i] = padValue;
        return dst;
    }

    /// <summary>
    /// Get rebound damping for a given piston velocity (ips).
    /// Uses valving tables if present, interpolates between 1ips and 3ips values.
    /// ReboundClicks is negative or zero; index used is -ReboundClicks.
    /// </summary>
    public float GetReboundForVelocity(float ips)
    {
        EnsureValvingArrays();
        int idx = -Clamp(ReboundClicks, -MaxNegativeClicks, 0); // maps 0 -> 0, -N -> N
        float v1 = _reboundAt1ips[idx];
        float v3 = _reboundAt3ips[idx];
        if (ips <= 1f) return v1;
        if (ips >= 3f) return v3;
        // linear interpolation between 1 and 3
        float t = (ips - 1f) / (3f - 1f);
        return v1 + (v3 - v1) * t;
    }

    /// <summary>
    /// Get compression damping for a given piston velocity (ips).
    /// Uses compression table at 3 ips as representative value.
    /// </summary>
    public float GetCompressionForVelocity(float ips)
    {
        EnsureValvingArrays();
        int idx = -Clamp(ReboundClicks, -MaxNegativeClicks, 0);
        return _compressionAt3ips[idx];
    }

    /// <summary>Increase rebound by one click (move towards 0, no-op if at 0).</summary>
    public void IncrementClick() => ReboundClicks = ReboundClicks + 1; // clamp ensures <= 0

    /// <summary>Decrease rebound by one click (move toward full soft, no-op if at -MaxNegativeClicks).</summary>
    public void DecrementClick() => ReboundClicks = ReboundClicks - 1; // clamp ensures >= -MaxNegativeClicks

    /// <summary>Set clicks and return whether it changed.</summary>
    public bool SetClicks(int clicks)
    {
        int clamped = Clamp(clicks, -MaxNegativeClicks, 0);
        if (clamped == _reboundClicks) return false;
        _reboundClicks = clamped;
        return true;
    }

    private static int Clamp(int v, int lo, int hi) => v < lo ? lo : (v > hi ? hi : v);

    public override string ToString() => $"Compression={Compression}, ReboundBase={ReboundBase}, Clicks={ReboundClicks}, Rebound={Rebound:F2}";

    // Optional helpers to export/import a simple spec format (CSV-like) kept inside Shock class
    public string ExportValvingSpec()
    {
        EnsureValvingArrays();
        // format: compression:comma list | rebound1:comma list | rebound3:comma list
        string c = string.Join(",", _compressionAt3ips.Select(x => x.ToString("F3")));
        string r1 = string.Join(",", _reboundAt1ips.Select(x => x.ToString("F3")));
        string r3 = string.Join(",", _reboundAt3ips.Select(x => x.ToString("F3")));
        return $"COMP3|{c}|REB1|{r1}|REB3|{r3}";
    }

    public void ImportValvingSpec(string spec)
    {
        if (string.IsNullOrWhiteSpace(spec)) return;
        // parse our simple format
        try
        {
            var parts = spec.Split('|');
            for (int i = 0; i < parts.Length - 1; i++) parts[i] = parts[i].Trim();
            // expected parts: COMP3, <csv>, REB1, <csv>, REB3, <csv>
            if (parts.Length >= 6 && parts[0] == "COMP3" && parts[2] == "REB1" && parts[4] == "REB3")
            {
                var c = parts[1].Split(',').Select(s => float.Parse(s.Trim())).ToArray();
                var r1 = parts[3].Split(',').Select(s => float.Parse(s.Trim())).ToArray();
                var r3 = parts[5].Split(',').Select(s => float.Parse(s.Trim())).ToArray();
                // SetValvingTables will normalize lengths
                SetValvingTables(c, r1, r3);
            }
        }
        catch { /* ignore parse errors */ }
    }

    // Preset factory methods retained but not used by UI when presets removed
    // NOTE: These values were transcribed visually and should be verified against the original sheet.
    public static Shock CreatePresetLF()
    {
        var s = new Shock();
        int len = s.MaxNegativeClicks + 1;
        float[] comp3 = Enumerable.Repeat(26f, len).ToArray();
        float[] reb1 = new float[] { 26f,26f,26f,27f,28f,29f,31f,33f,37f,41f,46f,62f,82f,100f,121f,149f,157f,157f,157f,157f,157f,157f,157f,157f,157f,157f,157f };
        float[] reb3 = new float[] { 33f,33f,33f,34f,36f,38f,41f,46f,55f,65f,80f,101f,128f,149f,157f,157f,157f,157f,157f,157f,157f,157f,157f,157f,157f,157f,157f };
        s.SetValvingTables(comp3, reb1, reb3);
        return s;
    }

    public static Shock CreatePresetRF()
    {
        var s = new Shock();
        int len = s.MaxNegativeClicks + 1;
        float[] comp3 = Enumerable.Repeat(35f, len).ToArray();
        float[] reb1 = new float[] { 22f,22f,22f,24f,26f,28f,33f,37f,41f,47f,55f,65f,85f,101f,113f,125f,128f,128f,128f,128f,128f,128f,128f,128f,128f,128f,128f };
        float[] reb3 = new float[] { 29f,29f,29f,31f,33f,36f,40f,45f,50f,60f,75f,90f,101f,113f,125f,128f,128f,128f,128f,128f,128f,128f,128f,128f,128f,128f,128f };
        s.SetValvingTables(comp3, reb1, reb3);
        return s;
    }

    public static Shock CreatePresetLR()
    {
        var s = new Shock();
        int len = s.MaxNegativeClicks + 1;
        float[] comp3 = Enumerable.Repeat(30f, len).ToArray();
        float[] reb1 = new float[] { 20f,20f,22f,24f,26f,30f,35f,45f,70f,90f,124f,198f,251f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f };
        float[] reb3 = new float[] { 22f,22f,24f,26f,30f,35f,45f,70f,101f,124f,198f,251f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f,255f };
        s.SetValvingTables(comp3, reb1, reb3);
        return s;
    }

    public static Shock CreatePresetRR()
    {
        var s = new Shock();
        int len = s.MaxNegativeClicks + 1;
        float[] comp3 = Enumerable.Repeat(40f, len).ToArray();
        float[] reb1 = new float[] { 26f,26f,28f,30f,32f,34f,38f,45f,64f,90f,118f,137f,154f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f };
        float[] reb3 = new float[] { 29f,29f,31f,33f,36f,40f,50f,64f,90f,118f,137f,154f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f,161f };
        s.SetValvingTables(comp3, reb1, reb3);
        return s;
    }
}
