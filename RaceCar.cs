public class RaceCar
{
    public CarCorner LeftFront { get; } = new CarCorner();
    public CarCorner RightFront { get; } = new CarCorner();
    public CarCorner LeftRear { get; } = new CarCorner();
    public CarCorner RightRear { get; } = new CarCorner();
    private readonly CarCorner[] _corners;
    public string CarName { get; set; } = "DEFAULT";
    public RaceCar()
    {
        _corners = new[] { LeftFront, RightFront, LeftRear, RightRear };
    }
    public float TotalWeight => _corners.Sum(c => c.Weight);
    public float CrossWeight => GetCornerWeight(Corner.LR) + GetCornerWeight(Corner.RF);
    public float LeftSideWeight => GetCornerWeight(Corner.LF) + GetCornerWeight(Corner.LR);
    public float RearWeight => GetCornerWeight(Corner.LR) + GetCornerWeight(Corner.RR);
    public float FrontStagger => GetTireSize(Corner.RF) - GetTireSize(Corner.LF);
    public float RearStagger => GetTireSize(Corner.RR) - GetTireSize(Corner.LR);
    public float Tilt => GetDifferenceOfAverage(GetTubeHeight(Corner.RF), GetTubeHeight(Corner.RR), GetTubeHeight(Corner.LF), GetTubeHeight(Corner.LR));
    public float Rake => GetDifferenceOfAverage(GetTubeHeight(Corner.RR), GetTubeHeight(Corner.LR), GetTubeHeight(Corner.RF), GetTubeHeight(Corner.LF));
    public float GetAverage(float a, float b) => (a + b) / 2;
    public float GetDifferenceOfAverage(float a, float b, float c, float d)
    {
        return GetAverage(a, b) - GetAverage(c, d);
    }
    private CarCorner GetCorner(Corner corner) => _corners[(int)corner];
    public Shock GetShock(Corner corner) => GetCorner(corner).Shock;     
    public void SetShock(Corner corner, Shock shock) => GetCorner(corner).Shock = shock;    
    public Tire GetWheel(Corner corner) => GetCorner(corner).Wheel;   
    public void SetWheel(Corner corner, Tire wheel) => GetCorner(corner).Wheel = wheel;
    public float GetCornerWeight(Corner corner) => GetCorner(corner).Weight;
    public void SetCornerWeight(Corner corner, float weight) => GetCorner(corner).Weight = weight;   
    public float GetTireSize(Corner corner) => GetCorner(corner).Wheel.TireDiameter;
    public void SetTireSize(Corner corner, float diameter) => GetCorner(corner).Wheel.SetDiameter(diameter);    
    public float GetTubeHeight(Corner corner) => GetCorner(corner).TubeHeight;
    public void SetTubeHeight(Corner corner, float height) => GetCorner(corner).TubeHeight = height;    
    public float GetTirePressure(Corner corner) => GetCorner(corner).Wheel.TirePressure;
    public void SetTirePressure(Corner corner, float pressure) => GetCorner(corner).Wheel.SetPressure(pressure);     
    public float GetBarDiameter(Corner corner) => GetCorner(corner).BarDiameter;
    public void SetBarDiameter(Corner corner, float rate) => GetCorner(corner).BarDiameter = rate;
   
}
public enum Corner { LF, RF, LR, RR }