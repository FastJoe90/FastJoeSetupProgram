public class RaceCar
{

    private string CarName { get; set; } = "Default";
    private  float[] CornerWeight { get; set; } = new float[4]; //Pounds
    private float[] TireDiameter { get; set; } = new float[4]; //Inches
    private float[] FrameHeight { get; set; } = new float[4]; //Inches
    private float TotalWeight => CornerWeight.Sum();
    private float CrossWeightPercentage => (CornerWeight[(int)Corner.LR] + CornerWeight[(int)Corner.RF]) / TotalWeight * 100;
    private float LeftSideWeightPercentage => (CornerWeight[(int)Corner.LR] + CornerWeight[(int)Corner.LF]) / TotalWeight * 100;
    private float RearWeightPercentage => (CornerWeight[(int)Corner.LR] + CornerWeight[(int)Corner.RR]) / TotalWeight * 100;
    private float FrontStagger => TireDiameter[(int)Corner.RF] - TireDiameter[(int)Corner.LF];
    private float RearStagger => TireDiameter[(int)Corner.RR] - TireDiameter[(int)Corner.LR];
    private float Tilt => ((FrameHeight[(int)Corner.RF] + FrameHeight[(int)Corner.RR]) / 2) - ((FrameHeight[(int)Corner.LF] + FrameHeight[(int)Corner.LR]) / 2);
    private float Rake => ((FrameHeight[(int)Corner.LR] + FrameHeight[(int)Corner.RR]) / 2) - ((FrameHeight[(int)Corner.LF] + FrameHeight[(int)Corner.RF]) / 2);
    public void SetCarName(string carName)
    {
        CarName = carName;
    }
    public void SetCornerWeightOne(Corner corner, float weight) //One = 1 Corner. ALL = ALL Corners
    {
        CornerWeight[(int)corner] = weight;
    }
    public void SetCornerWeightAll(float lF, float rF, float lR, float rR)
    {
        CornerWeight[(int)Corner.LF] = lF;
        CornerWeight[(int)Corner.RF] = rF;
        CornerWeight[(int)Corner.LR] = lR;
        CornerWeight[(int)Corner.RR] = rR;
    }
    public void SetTireSizeOne(Corner corner, float diameter)
    {
        TireDiameter[(int)corner] = diameter;
    }
    public void SetTireSizeAll(float lF, float rF, float lR, float rR)
    {
        TireDiameter[(int)Corner.LF] = lF;
        TireDiameter[(int)Corner.RF] = rF;
        TireDiameter[(int)Corner.LR] = lR;
        TireDiameter[(int)Corner.RR] = rR;
    }
    public void SetFrameHeightOne(Corner corner, float height)
    {
        FrameHeight[(int)corner] = height;
    }
    public void SetFrameHeightAll(float lF, float rF, float lR, float rR)
    {
        FrameHeight[(int)Corner.LF] = lF;
        FrameHeight[(int)Corner.RF] = rF;
        FrameHeight[(int)Corner.LR] = lR;
        FrameHeight[(int)Corner.RR] = rR;
    }
    //Descriptive Methods.
    public void DisplayCarName() => Console.WriteLine($"{CarName}");
    public void DisplayAllPercentages()
    {
        DisplayCrossWeight();
        DisplayLeftWeight();
        DisplayRearWeight();
    }
    public void DisplayTotalWeight() => Console.WriteLine($"{TotalWeight:0.0} Total Weight in Lbs.");
    public void DisplayCrossWeight() => Console.WriteLine($"{CrossWeightPercentage:0.00}% Cross Weight");
    public void DisplayLeftWeight() => Console.WriteLine($"{LeftSideWeightPercentage:0.00}% Left Side Weight");
    public void DisplayRearWeight() => Console.WriteLine($"{RearWeightPercentage:0.00}% Rear Weight");
    public void DisplayFrontStagger() => Console.WriteLine($"{FrontStagger:0.00}\" Front Stagger");
    public void DisplayRearStagger() => Console.WriteLine($"{RearStagger:0.00}\" Rear Stagger");
    public void DisplayRake() => Console.WriteLine($"{Rake:0.00}\" of Rake"); //Negatives should be possible for Rake and Tilt
    public void DisplayTilt() => Console.WriteLine($"{Tilt:0.00}\" of Tilt");
    public void DisplayAllRideHeights()
    {
        Console.WriteLine($"LEFT FRONT: {FrameHeight[(int)Corner.LF]}\"    RIGHT FRONT: {FrameHeight[(int)Corner.RF]}\"");
        Console.WriteLine($"LEFT REAR:  {FrameHeight[(int)Corner.LR]}\"     RIGHT REAR: {FrameHeight[(int)Corner.RR]}\"");
    }
}
public enum Corner { LF, RF, LR, RR }