public class Shock
{   
    public float Rebound { get; set; }   
    public float Compression { get; set; }   
    public int MaxNegativeClicks { get; init; } = 26; //Controls the range of clicks in the UI.

    private int _reboundClicks;
 
    public int ReboundClicks
    {
        get => _reboundClicks;
        set => _reboundClicks = Clamp(value, -MaxNegativeClicks, 0);
    }  

    public Shock()
    {
        // default to 0 clicks
        _reboundClicks = 0;
    }

    public Shock(float compression, float reboundBase, int initialClicks = 0, int maxNegativeClicks = 26)
    {
        Compression = compression;
        Rebound = reboundBase;
        MaxNegativeClicks = maxNegativeClicks;
        _reboundClicks = Clamp(initialClicks, -MaxNegativeClicks, 0);
    }  
    public void IncrementClick() => ReboundClicks = ReboundClicks + 1; // clamp ensures <= 0   
    public void DecrementClick() => ReboundClicks = ReboundClicks - 1; // clamp ensures >= -MaxNegativeClicks  
    public bool SetClicks(int clicks)
    {
        int clamped = Clamp(clicks, -MaxNegativeClicks, 0);
        if (clamped == _reboundClicks) return false;
        _reboundClicks = clamped;
        return true;
    }

    private static int Clamp(int v, int lo, int hi) => v < lo ? lo : (v > hi ? hi : v);

    public override string ToString() => $"Compression={Compression}, ReboundBase={Rebound}, Clicks={ReboundClicks}, Rebound={Rebound:F2}";
}
