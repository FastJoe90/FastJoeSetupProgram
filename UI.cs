public class UI
{
    private const int HeaderWidth = 50;
    public static void VersionInfo()
    {
        InsertHeaderBreak();        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(AppInfo.Name);
        Console.WriteLine($"Version: {AppInfo.Version}");
        Console.ResetColor();
        InsertHeaderBreak();
        Console.WriteLine();
    }
    public static void DisplayMainMenu()
    {
        InsertTitleHeader("Main Menu");
        Console.WriteLine("1 - Enter New Setup");
        Console.WriteLine("2 - Display Current Setup Sheet");
        Console.WriteLine("3 - Display Current Stagger");
        Console.WriteLine("4 - Display Current Weight Percentages");
        Console.WriteLine("5 - Display Current Rake/Tilt");
        Console.WriteLine("6 - Close Program");
        InsertHeaderBreak();
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

    //DISPLAY METHODS

    
    public static void ShowAllPercentages(RaceCar car)
    {
        ShowCrossWeight(car);
        ShowLeftWeight(car);
        ShowRearWeight(car);
    }
    public static void DisplayFullSetup(RaceCar car)
    {
        Console.Clear();              
        InsertTitleHeader("FULL SETUP SHEET");
        DisplaySectionHeader("RACE CAR CLASS");       
        ShowCarName(car);
        InsertHeaderBreak();        
        DisplaySectionHeader("VEHICLE WEIGHTS");     
        ShowTotalWeight(car);
        ShowAllPercentages(car);
        InsertSectionBreak();
        DisplaySectionHeader("RIDE HEIGHTS");        
        ShowAllRideHeights(car);
        ShowRake(car);
        ShowTilt(car);
        InsertSectionBreak();      
        DisplaySectionHeader("TIRE INFO");       
        ShowFrontStagger(car);
        ShowRearStagger(car);       
        InsertSectionBreak();
        
    }
    public static void ShowCarName(RaceCar car) => Console.WriteLine($"{"DIVISION:",-40}{car.CarName.ToUpper()}");
    public static void ShowTotalWeight(RaceCar car) => Console.WriteLine($"{"TOTAL WEIGHT:",-40} {car.TotalWeight:0.0} lbs.");
    public static void ShowCrossWeight(RaceCar car) => Console.WriteLine($"{"CROSS WEIGHT:",-40} {car.CrossWeightPercentage:0.00}%");
    public static void ShowLeftWeight(RaceCar car) => Console.WriteLine($"{"LEFT SIDE WEIGHT:",-40} {car.LeftSideWeightPercentage:0.00}%");
    public static void ShowRearWeight(RaceCar car) => Console.WriteLine($"{"REAR WEIGHT:",-40} {car.RearWeightPercentage:0.00}%");
    public static void ShowFrontStagger(RaceCar car) => Console.WriteLine($"{"FRONT STAGGER:",-40} {car.FrontStagger:0.00}\"");
    public static void ShowRearStagger(RaceCar car) => Console.WriteLine($"{"REAR STAGGER:",-40} {car.RearStagger:0.00}\"");
    public static void ShowRake(RaceCar car) => Console.WriteLine($"{"RAKE:",-17} {car.Rake:0.00}\" |"); //Negatives should be allowed here.    
    public static void ShowTilt(RaceCar car) => Console.WriteLine($"{"TILT:",-17} {car.Tilt:0.00}\" |"); //Negatives should be allowed her.   
    public static void ShowAllRideHeights(RaceCar car)
    {
        Console.WriteLine($"LEFT FRONT: {car.GetFrameHeight(Corner.LF),-10:0.00}\" | RIGHT FRONT: {car.GetFrameHeight(Corner.RF),-10:0.00}\"");
        Console.WriteLine($"LEFT REAR:  {car.GetFrameHeight(Corner.LR),-10:0.00}\" | RIGHT REAR:  {car.GetFrameHeight(Corner.RR),-10:0.00}\"");
    }

    //HELPER UTILITIES

    //UI Design Methods
    private static void InsertTitleHeader(string titleName) //Uses double dashed line.
    {             
        int padding = (HeaderWidth - titleName.Length) / 2; 
        int paddedLength = titleName.Length + padding; // The length needed to pad left      
        InsertHeaderBreak();
        Console.WriteLine(titleName.PadLeft(paddedLength).PadRight(HeaderWidth));        
        InsertHeaderBreak();     
    }
    private static void InsertHeaderBreak() => Console.WriteLine("=================================================="); //Used for section breaks.
    private static void InsertSectionBreak() => Console.WriteLine("--------------------------------------------------");
    private static void DisplaySectionHeader(string sectionName) //Uses single dashed line.
    {           
        int padding = (HeaderWidth - sectionName.Length) / 2;
        int paddedLength = sectionName.Length + padding;
        InsertSectionBreak();
        Console.WriteLine(sectionName.PadLeft(paddedLength).PadRight(HeaderWidth));
        InsertSectionBreak();       
    }

    //Input validation methods.

    private static string GetValidString(string inputMessage)
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
    public static void InvalidInput(string inputMessage = "Not a valid choice!") //Will default to Not a valid choice if left parameterless.
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(inputMessage);
        Console.ResetColor();        
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
    public static float GetValidFloat(string inputMessage = "Please enter your choice: ") 
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
    //Use this to create pause points in the UI.
    public static void PressAnyKey()
    {       
        Console.Write("Press ANY key to Continue: ");        
        Console.ReadKey();
        Console.WriteLine();
    }
    public static bool EndProgram() //Message to end the session, along with the return value needed to break the main program loop.
    {
        Console.WriteLine("\nHave a good night!");
        PressAnyKey();
        return true;
    }

}