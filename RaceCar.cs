public class RaceCar
{
    private readonly float[] _cornerWeight = { 0, 0, 0, 0 };//Pounds    
    private readonly float[] _tubeHeight = { 0, 0, 0, 0 }; //Inches
    private readonly float[] _tirePressure = { 0, 0, 0, 0 }; //PSI
    private readonly float[] _barDiameter = { 0, 0, 0, 0 }; // inches (torsion bar diameter per corner)

    // Per-corner shocks
    private readonly Shock[] _shocks =
    {
        new Shock(), new Shock(), new Shock(), new Shock(),
    };
    private readonly Wheel[] _wheel =
    {
        new Wheel(), new Wheel(), new Wheel(), new Wheel(),
    };

    public string CarName { get; set; } = "DEFAULT";

    public RaceCar()
    {
       
    }

    public float TotalWeight => _cornerWeight.Sum();
    public float CrossWeight => GetCornerWeight(Corner.LR) + GetCornerWeight(Corner.RF);
    public float LeftSideWeight => GetCornerWeight(Corner.LF) + GetCornerWeight(Corner.LR);
    public float RearWeight => GetCornerWeight(Corner.LR) + GetCornerWeight(Corner.RR);
    public float FrontStagger => GetTireSize(Corner.RF) - GetTireSize(Corner.LF);
    public float RearStagger => GetTireSize(Corner.RR) - GetTireSize(Corner.LR);
    public float Tilt => GetAverage(_tubeHeight[(int)Corner.RF], _tubeHeight[(int)Corner.RR], _tubeHeight[(int)Corner.LF], _tubeHeight[(int)Corner.LR]);
    public float Rake => GetAverage(_tubeHeight[(int)Corner.LR], _tubeHeight[(int)Corner.RR], _tubeHeight[(int)Corner.LF], _tubeHeight[(int)Corner.RF]);

    // Expose shocks per corner
    public Shock GetShock(Corner corner) => _shocks[(int)corner];
    public void SetShock(Corner corner, Shock shock) => _shocks[(int)corner] = shock;
    // Expose Wheels and Tires per corner. This is goign to change to 2 classes very quick.
    public Wheel GetWheel(Corner corner) => _wheel[(int)corner];
    public void SetWheel(Corner corner, Wheel wheel) => _wheel[(int)corner] = wheel;

    //Simple helper method
    public float GetAverage(float a, float b) => (a + b) / 2; 
    public float GetAverage(float a, float b, float c, float d)
    {
        return GetAverage(a, b) - GetAverage(c, d);
    }
    
    public float GetCornerWeight(Corner corner) => _cornerWeight[(int)corner];
    public void SetCornerWeight(Corner corner, float weight) 
    {
        _cornerWeight[(int)corner] = weight;
    }
    public float GetTireSize(Corner corner) => _wheel[(int)corner].TireDiameter;
    public void SetTireSize(Corner corner, float diameter)
    {
        _wheel[(int)corner].TireDiameter = diameter;
    }
    public float GetTubeHeight(Corner corner) => _tubeHeight[(int)corner];
    public void SetTubeHeight(Corner corner, float height)
    {
        _tubeHeight[(int)corner] = height;
    }
    public float GetTirePressure(Corner corner) => _tirePressure[(int)corner];
    public void SetTirePressure(Corner corner, float pressure)
    {
        _tirePressure[(int)corner] = pressure;
    }
    // Bar diameter accessors
    public float GetBarDiameter(Corner corner) => _barDiameter[(int)corner];
    public void SetBarDiameter(Corner corner, float rate)
    {
        _barDiameter[(int)corner] = rate;
    }
}
public enum Corner { LF, RF, LR, RR }