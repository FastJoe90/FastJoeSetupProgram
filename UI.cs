
public class UI
{
    public static void VersionInfo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(AppInfo.Name);
        Console.WriteLine($"Version: {AppInfo.Version}");
        Console.ResetColor();
    }
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
    public static string AskCarName()
    {
        return UserInput("Please enter the TYPE of car you are working on");
    }
    public static float AskTireDiameter(string vehicleCorner)
    {
        return ValidNumber($"Enter {vehicleCorner} Tire Size: ");
    }
    public static float AskCornerWeight(string vehicleCorner)
    {
        return ValidNumber($"Enter {vehicleCorner} Corner Weight: ");
    }
    public static float AskFrameHeight(string vehicleCorner)
    {
        return ValidNumber($"Enter {vehicleCorner} Frame Height: ");
    }
    public static void ShowCarName(RaceCar car) => Console.WriteLine($"{car.GetCarName()}");
    public static void ShowAllPercentages(RaceCar car)
    {
        ShowCrossWeight(car);
        ShowLeftWeight(car);
        ShowRearWeight(car);
    }
    public static void DisplayFullSetup(RaceCar car)
    {
        ShowCarName(car);
        ShowTotalWeight(car);
        ShowAllPercentages(car);
        ShowAllRideHeights(car);
        ShowFrontStagger(car);
        ShowRearStagger(car);
        ShowRake(car);
        ShowTilt(car);
    }
    public static void ShowTotalWeight(RaceCar car) => Console.WriteLine($"TOTAL WEIGHT: {car.TotalWeight:0.0} lbs.");
    public static void ShowCrossWeight(RaceCar car) => Console.WriteLine($"CROSS WEIGHT: {car.CrossWeightPercentage:0.00}%");
    public static void ShowLeftWeight(RaceCar car) => Console.WriteLine($"LEFT SIDE WEIGHT: {car.LeftSideWeightPercentage:0.00}%");
    public static void ShowRearWeight(RaceCar car) => Console.WriteLine($"REAR WEIGHT: {car.RearWeightPercentage:0.00}%");
    public static void ShowFrontStagger(RaceCar car) => Console.WriteLine($"FRONT STAGGER: {car.FrontStagger:0.00}\"");
    public static void ShowRearStagger(RaceCar car) => Console.WriteLine($"REAR STAGGER: {car.RearStagger:0.00}\"");
    public static void ShowRake(RaceCar car) => Console.WriteLine($"RAKE: {car.Rake:0.00}\""); //Negatives should be allowed here.    
    public static void ShowTilt(RaceCar car) => Console.WriteLine($"TILT: {car.Tilt:0.00}\""); //Negatives should be allowed her.   
    public static void ShowAllRideHeights(RaceCar car)
    {
        Console.WriteLine($"LEFT FRONT: {car.GetFrameHeight(Corner.LF)}\"    RIGHT FRONT: {car.GetFrameHeight(Corner.RF)}\"");
        Console.WriteLine($"LEFT REAR:  {car.GetFrameHeight(Corner.LR)}\"     RIGHT REAR: {car.GetFrameHeight(Corner.RR)}\"");
    }
    public static string UserInput(string inputMessage)
    {
        Console.WriteLine(inputMessage);
        return Console.ReadLine();
    }
    public static void InvalidInput()
    {
        Console.Beep(350, 500);

        Console.WriteLine("Not a valid choice!");
        AnyKey();
    }
    public static int ValidNumber()
    {
        while (true)
        {
            Console.Write($"Choose an option: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int number))
            {
                return number;
            }
            else
            {
                InvalidInput();
            }
        }
    }
    public static float ValidNumber(string inputMessage) //Input validation method.
    {
        while (true)
        {
            Console.Write(inputMessage);
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float number))
            {
                return number;
            }
            else
            {
                InvalidInput();
            }
        }
    }
    public static bool EndProgram()
    {
        Console.WriteLine("Have a good night!");
        AnyKey();
        return true;
    }
    public static void AnyKey()
    {
        Console.Write("Press ANY key to Continue: ");
        Console.ReadKey();
        Console.WriteLine();
    }

}