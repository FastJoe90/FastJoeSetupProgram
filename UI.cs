
public class UI
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine("===========MAIN MENU===========");
        Console.WriteLine("1 - Enter New Setup");
        Console.WriteLine("2 - Display Current Setup Sheet");
        Console.WriteLine("3 - Display Current Stagger");
        Console.WriteLine("4 - Display Current Weight Percentages");
        Console.WriteLine("5 - Display Current Rake/Tilt");
        Console.WriteLine("6 - Close Program");
        Console.WriteLine("===============================");
    }
    public static void DisplayCarName(RaceCar car) => Console.WriteLine($"{car.GetCarName()}");
    public static void DisplayAllPercentages(RaceCar car)
    {
        DisplayCrossWeight(car);
        DisplayLeftWeight(car);
        DisplayRearWeight(car);
    }
    public static void DisplayFullSetup(RaceCar car)
    {
       DisplayCarName(car);
        DisplayTotalWeight(car);
        DisplayAllPercentages(car);
        DisplayAllRideHeights(car);
        DisplayFrontStagger(car);
        DisplayRearStagger(car);
        DisplayRake(car);
        DisplayTilt(car);
    }
    public static void DisplayTotalWeight(RaceCar car) => Console.WriteLine($"TOTAL WEIGHT: {car.TotalWeight:0.0} lbs.");
    public static void DisplayCrossWeight(RaceCar car) => Console.WriteLine($"CROSS WEIGHT: {car.CrossWeightPercentage:0.00}%");
    public static void DisplayLeftWeight(RaceCar car) => Console.WriteLine($"LEFT SIDE WEIGHT: {car.LeftSideWeightPercentage:0.00}%");
    public static void DisplayRearWeight(RaceCar car) => Console.WriteLine($"REAR WEIGHT: {car.RearWeightPercentage:0.00}%");
    public static void DisplayFrontStagger(RaceCar car) => Console.WriteLine($"FRONT STAGGER: {car.FrontStagger:0.00}\"");
    public static void DisplayRearStagger(RaceCar car) => Console.WriteLine($"REAR STAGGER: {car.RearStagger:0.00}\"");
    public static void DisplayRake(RaceCar car) => Console.WriteLine($"RAKE: {car.Rake:0.00}\""); //Negatives should be allowed here.    
    public static void DisplayTilt(RaceCar car) => Console.WriteLine($"TILT: {car.Tilt:0.00}\""); //Negatives should be allowed her.   
    public static void DisplayAllRideHeights(RaceCar car)
    {
        Console.WriteLine($"LEFT FRONT: {car.GetFrameHeight(Corner.LF)}\"    RIGHT FRONT: {car.GetFrameHeight(Corner.RF)}\"");
        Console.WriteLine($"LEFT REAR:  {car.GetFrameHeight(Corner.LR)}\"     RIGHT REAR: {car.GetFrameHeight(Corner.RR)}\"");
    }

}