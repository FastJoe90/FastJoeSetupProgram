public class Tire
{
     //Measured differently on different style vehicles. For now, this will work. In Inches.   
    public float TirePressure { get; private set; } //Measured in PSI.
    public float TireDiameter { get; private set; } //Measured in inches.
    private float PressureIncrement { get; } = 0.5f; //Typical pressure adjustments would be done by half pound. Adjust to needs.
    private float DiameterIncrement { get; } = 0.125f; //Tire stagger generally is measure in 1/8ths. Again, adjust to needs.
    public Tire(float pressure = 0, float diameter = 0)
    {     
        TirePressure = pressure;
        TireDiameter = diameter;
    }  
    //For setting an initial pressure.
    public void SetPressure(float pressure) => TirePressure = Math.Max(0, pressure);
    //For adding/lowering tire pressure by increments. NEEDS IMPLEMENTED.
    public void AddAir() => TirePressure = Math.Max(0, TirePressure + PressureIncrement);
    public void RemoveAir() => TirePressure = Math.Max(0, TirePressure - PressureIncrement);
    //For setting and initial tire size.
    public void SetDiameter(float diameter) => TireDiameter = Math.Max(0, diameter);
    //For increasing/decreasing tire size by increments. NEEDS IMPLEMENTED.
    public void IncreaseDiameter() => TireDiameter = Math.Max(0, TireDiameter + DiameterIncrement);
    public void DecreaseDiameter() => TireDiameter = Math.Max(0, TireDiameter - DiameterIncrement);
        
}