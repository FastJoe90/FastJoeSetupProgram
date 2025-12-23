public class RaceCar
{
    private readonly float[] _cornerWeight = { 0, 0, 0, 0 };//Pounds
    private readonly float[] _tireRunOut = { 0, 0, 0, 0 }; //Inches
    private readonly float[] _tubeHeight = { 0, 0, 0, 0 }; //Inches
    private readonly float[] _tirePressure = { 0, 0, 0, 0 }; //PSI
    private readonly float[] _barDiameter = { 0, 0, 0, 0 }; // inches (torsion bar diameter per corner)

    // Per-corner shocks
    private readonly Shock[] _shocks = new Shock[4];

    public string CarName { get; set; } = "DEFAULT";

    public RaceCar()
    {
        // initialize shocks to default instances
        _shocks[(int)Corner.LF] = new Shock();
        _shocks[(int)Corner.RF] = new Shock();
        _shocks[(int)Corner.LR] = new Shock();
        _shocks[(int)Corner.RR] = new Shock();
    }

    public float TotalWeight => _cornerWeight.Sum();
    public float CrossWeight => _cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.RF];
    public float LeftSideWeight => _cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.LF];
    public float RearWeight => _cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.RR];
    public float FrontStagger => _tireRunOut[(int)Corner.RF] - _tireRunOut[(int)Corner.LF];
    public float RearStagger => _tireRunOut[(int)Corner.RR] - _tireRunOut[(int)Corner.LR];
    public float Tilt => GetAverage(_tubeHeight[(int)Corner.RF], _tubeHeight[(int)Corner.RR]) - GetAverage(_tubeHeight[(int)Corner.LF], _tubeHeight[(int)Corner.LR]);
    public float Rake => GetAverage(_tubeHeight[(int)Corner.LR], _tubeHeight[(int)Corner.RR]) - GetAverage(_tubeHeight[(int)Corner.LF], _tubeHeight[(int)Corner.RF]);

    // Expose shocks per corner
    public Shock GetShock(Corner corner) => _shocks[(int)corner];
    public void SetShock(Corner corner, Shock shock) => _shocks[(int)corner] = shock ?? new Shock();

    public float GetAverage(float a, float b) => (a + b) / 2;   
    public float GetCornerWeight(Corner corner) => _cornerWeight[(int)corner];
    public void SetCornerWeight(Corner corner, float weight) //One = 1 Corner. ALL = ALL Corners
    {
        _cornerWeight[(int)corner] = weight;
    }    
    public float GetTireSize(Corner corner) => _tireRunOut[(int)corner];
    public void SetTireSize(Corner corner, float diameter)
    {
        _tireRunOut[(int)corner] = diameter;
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