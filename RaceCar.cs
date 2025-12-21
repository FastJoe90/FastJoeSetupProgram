public class RaceCar
{
    private readonly float[] _cornerWeight = { 0, 0, 0, 0 };//Pounds
    private readonly float[] _tireDiameter = { 0, 0, 0, 0 }; //Inches
    private readonly float[] _frameHeight = { 0, 0, 0, 0 }; //Inches
    private readonly float[] _tirePressure = { 0, 0, 0, 0 }; //PSI
    public string CarName { get; set; } = "DEFAULT";
    public float TotalWeight => _cornerWeight.Sum();
    public float CrossWeight => _cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.RF];
    public float LeftSideWeight => _cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.LF];
    public float RearWeight => _cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.RR];
    public float FrontStagger => _tireDiameter[(int)Corner.RF] - _tireDiameter[(int)Corner.LF];
    public float RearStagger => _tireDiameter[(int)Corner.RR] - _tireDiameter[(int)Corner.LR];
    public float Tilt => GetAverage(_frameHeight[(int)Corner.RF], _frameHeight[(int)Corner.RR]) - GetAverage(_frameHeight[(int)Corner.LF], _frameHeight[(int)Corner.LR]);
    public float Rake => GetAverage(_frameHeight[(int)Corner.LR], _frameHeight[(int)Corner.RR]) - GetAverage(_frameHeight[(int)Corner.LF], _frameHeight[(int)Corner.RF]);
    public float GetAverage(float a, float b) => (a + b) / 2;   
    public float GetCornerWeight(Corner corner) => _cornerWeight[(int)corner];
    public void SetCornerWeight(Corner corner, float weight) //One = 1 Corner. ALL = ALL Corners
    {
        _cornerWeight[(int)corner] = weight;
    }    
    public float GetTireSize(Corner corner) => _tireDiameter[(int)corner];
    public void SetTireSize(Corner corner, float diameter)
    {
        _tireDiameter[(int)corner] = diameter;
    }
    public float GetFrameHeight(Corner corner) => _frameHeight[(int)corner];
    public void SetFrameHeight(Corner corner, float height)
    {
        _frameHeight[(int)corner] = height;
    }
    public float GetTirePressure(Corner corner) => _tirePressure[(int)corner];
    public void SetTirePressure(Corner corner, float pressure)
    {
        _tirePressure[(int)corner] = pressure;
    }
}
public enum Corner { LF, RF, LR, RR }