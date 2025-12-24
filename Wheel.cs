
public class Wheel
{
    public float Spacing { get; private set; } //Measured differently on different style vehicles. For now, this will work. In Inches.   
    public float TirePressure { get; private set; } //Measured in PSI.
    public float TireDiameter { get; private set; } //Measured in inches.
    private float SpacerSize { get; init; } = 0.25f;
    private float PressureIncrement { get; init; } = 0.5f;
    private float DiameterIncrement { get; init; } = 0.125f;
   

    public Wheel(float spacing = 0, float pressure = 0, float diameter = 0)
    {
        Spacing = spacing;
        TirePressure = pressure;
        TireDiameter = diameter;
    }
    public void SetWheelSpacing(float spacing) => Spacing = Math.Max(0, spacing);
    public void AddSpacer() => Spacing = Math.Max(0, Spacing + SpacerSize);
    public void RemoveSpacer() => Spacing = Math.Max(0, Spacing - SpacerSize);
    public void SetPressure(float pressure) => TirePressure = Math.Max(0, pressure);
    public void AddAir() => TirePressure = Math.Max(0, TirePressure + PressureIncrement);
    public void RemoveAir() => TirePressure = Math.Max(0, TirePressure - PressureIncrement);
    public void SetDiameter(float diameter) => TireDiameter = Math.Max(0, diameter);
    public void IncreaseDiameter() => TireDiameter = Math.Max(0, TireDiameter + DiameterIncrement);
    public void DecreaseDiameter() => TireDiameter = Math.Max(0, TireDiameter - DiameterIncrement);
        
}