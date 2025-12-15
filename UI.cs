
public class UI
{
    public static void VersionInfo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(AppInfo.Name);
        Console.WriteLine("");
        Console.WriteLine($"Version: {AppInfo.Version}");
        Console.ResetColor();
        Console.WriteLine();
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
    public static bool EndProgram()
    {
        Console.WriteLine("Have a good night!");
        PressAnyKey();
        return true;
    }

    //INPUT METHODS

    public static string AskCarName()
    {
        return GetValidString("Please enter the TYPE of car you are working on");
    }
    public static float AskTireDiameter(string vehicleCorner)
    {
        return GetValidFloat($"Enter {vehicleCorner} Tire Size: ");
    }
    public static float AskCornerWeight(string vehicleCorner)
    {
        return GetValidFloat($"Enter {vehicleCorner} Corner Weight: ");
    }
    public static float AskFrameHeight(string vehicleCorner)
    {
        return GetValidFloat($"Enter {vehicleCorner} Frame Height: ");
    }

    //Report Methods

    public static void ShowCarName(RaceCar car) => Console.WriteLine($"{car.CarName}");
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

    //Helper utilities
    public static string GetValidString(string inputMessage)
    {
        while (true)
        {
            Console.WriteLine(inputMessage);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) //Check if null or blank.
            {
                return input;
            }
            InvalidInput("Input cannot be empty");
        }
    }
    public static void InvalidInput(string inputMessage = "Not a valid choice!") //Insert string to get custom message.
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(inputMessage);
        Console.ResetColor();
        PressAnyKey();
    }
    public static int GetValidInt()
    {
        while (true)
        {
            Console.Write("Enter your choice: ");
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
    public static float GetValidFloat(string inputMessage = "Please enter your choice: ") //Input validation method.
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
    public static void PressAnyKey()
    {
        Console.Write("Press ANY key to Continue: ");
        Console.ReadKey();
        Console.WriteLine();
    }

}