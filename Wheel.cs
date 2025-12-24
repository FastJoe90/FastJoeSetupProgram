public class Wheel
{
    public float RimOffset { get; set; } //Measured differently on different style vehicles. For now, this will work. In Inches.   
    public float TirePressure { get; set; } //Measured in PSI.
    public float TireDiameter { get; set; } //Measured in inches.
    
    public Wheel()
    {
        RimOffset = 0;
        TirePressure = 0;
        TireDiameter = 0;
    }

    public Wheel(float rimOffset, float tirePressure, float tireDiameter)
    {
        RimOffset = rimOffset;
        TirePressure = tirePressure;
        TireDiameter = tireDiameter;
    }
    public void IncreaseClick(float value)
    {
        if (value == RimOffset) value += 0.25f;
        if (value == TirePressure) value += 0.50f;
        if (value == TireDiameter) value += 0.125f;        
    }
    public void DecreaseClick(float value)
    {
        if (value == RimOffset) value -= 0.25f;
        if (value == TirePressure) value += 0.50f;
        if (value == TireDiameter) value += 0.125f;
    }
    private static int Clamp(int v, int lo, int hi) => v < lo ? lo : (v > hi ? hi : v);
}