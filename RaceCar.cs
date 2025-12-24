public class RaceCar
{
    public Corner LeftFront { get; } = new Corner();
    public Corner RightFront { get; } = new Corner();
    public Corner LeftRear { get; } = new Corner();
    public Corner RightRear { get; } = new Corner();
    private readonly Corner[] _corners;
    public string CarName { get; set; } = "DEFAULT";

    public RaceCar()
    {
        _corners = new[] { LeftFront, RightFront, LeftRear, RightRear };
    }

    public float TotalWeight => _corners.Sum(c => c.Weight);
    public float CrossWeight => GetCornerWeight(Corners.LR) + GetCornerWeight(Corners.RF);
    public float LeftSideWeight => GetCornerWeight(Corners.LF) + GetCornerWeight(Corners.LR);
    public float RearWeight => GetCornerWeight(Corners.LR) + GetCornerWeight(Corners.RR);
    public float FrontStagger => GetTireSize(Corners.RF) - GetTireSize(Corners.LF);
    public float RearStagger => GetTireSize(Corners.RR) - GetTireSize(Corners.LR);
    public float Tilt => GetDifferenceOfAverage(GetTubeHeight(Corners.RF), GetTubeHeight(Corners.RR), GetTubeHeight(Corners.LF), GetTubeHeight(Corners.LR));
    public float Rake => GetDifferenceOfAverage(GetTubeHeight(Corners.RR), GetTubeHeight(Corners.LR), GetTubeHeight(Corners.RF), GetTubeHeight(Corners.LF));
    public float GetAverage(float a, float b) => (a + b) / 2;
    public float GetDifferenceOfAverage(float a, float b, float c, float d)
    {
        return GetAverage(a, b) - GetAverage(c, d);
    }
    private Corner GetCorner(Corners corner) => _corners[(int)corner];
    public Shock GetShock(Corners corner) => GetCorner(corner).Shock;     
    public void SetShock(Corners corner, Shock shock) => GetCorner(corner).Shock = shock;    
    public Wheel GetWheel(Corners corner) => GetCorner(corner).Wheel;   
    public void SetWheel(Corners corner, Wheel wheel) => GetCorner(corner).Wheel = wheel;
    public float GetCornerWeight(Corners corner) => GetCorner(corner).Weight;
    public void SetCornerWeight(Corners corner, float weight) => GetCorner(corner).Weight = weight;   
    public float GetTireSize(Corners corner) => GetCorner(corner).Wheel.TireDiameter;
    public void SetTireSize(Corners corner, float diameter) => GetCorner(corner).Wheel.SetDiameter(diameter);    
    public float GetTubeHeight(Corners corner) => GetCorner(corner).TubeHeight;
    public void SetTubeHeight(Corners corner, float height) => GetCorner(corner).TubeHeight = height;    
    public float GetTirePressure(Corners corner) => GetCorner(corner).Wheel.TirePressure;
    public void SetTirePressure(Corners corner, float pressure) => GetCorner(corner).Wheel.SetPressure(pressure);     
    public float GetBarDiameter(Corners corner) => GetCorner(corner).BarDiameter;
    public void SetBarDiameter(Corners corner, float rate) => GetCorner(corner).BarDiameter = rate;
   
}
public enum Corners { LF, RF, LR, RR }