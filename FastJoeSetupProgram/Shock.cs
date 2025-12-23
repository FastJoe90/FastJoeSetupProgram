public class Shock
{   
    public float Rebound { get; set; }   
    public float Compression { get; set; } 
    
    //setting for Micro Sprint shock (which is base vehicle we are working on
    //Consider different values when working on different vehicles (Or no adjustment at all)
    public int MaxNegativeClicks { get; init; } = 26;  

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

    public Shock(float compression, float rebound, int initialClicks = 0, int maxNegativeClicks = 26)
    {
        Compression = compression;
        Rebound = rebound;
        MaxNegativeClicks = maxNegativeClicks;
        _reboundClicks = Clamp(initialClicks, -MaxNegativeClicks, 0);
    }  
    public void IncrementClick() => ReboundClicks = ReboundClicks + 1; 
    public void DecrementClick() => ReboundClicks = ReboundClicks - 1; 
    private static int Clamp(int v, int lo, int hi) => v < lo ? lo : (v > hi ? hi : v);

    public override string ToString() => $"Compression={Compression}, ReboundBase={Rebound}, Clicks={ReboundClicks}, Rebound={Rebound:F2}";
}
