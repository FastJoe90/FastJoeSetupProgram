public class RaceCar
{    
    private readonly float[] _cornerWeight = new float[4]; //Pounds
    private readonly float[] _tireDiameter = new float[4]; //Inches
    private readonly float[] _frameHeight = new float[4]; //Inches
    public string CarName { get; set; } = "Default";
    public float TotalWeight => _cornerWeight.Sum();
    public float CrossWeightPercentage => (_cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.RF]) / TotalWeight * 100;
    public float LeftSideWeightPercentage => (_cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.LF]) / TotalWeight * 100;
    public float RearWeightPercentage => (_cornerWeight[(int)Corner.LR] + _cornerWeight[(int)Corner.RR]) / TotalWeight * 100;
    public float FrontStagger => _tireDiameter[(int)Corner.RF] - _tireDiameter[(int)Corner.LF];
    public float RearStagger => _tireDiameter[(int)Corner.RR] - _tireDiameter[(int)Corner.LR];
    public float Tilt => ((_frameHeight[(int)Corner.RF] + _frameHeight[(int)Corner.RR]) / 2) - ((_frameHeight[(int)Corner.LF] + _frameHeight[(int)Corner.LR]) / 2);
    public float Rake => ((_frameHeight[(int)Corner.LR] + _frameHeight[(int)Corner.RR]) / 2) - ((_frameHeight[(int)Corner.LF] + _frameHeight[(int)Corner.RF]) / 2);
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
}
public enum Corner { LF, RF, LR, RR }