public class SetupController
{
    //Allowing the UI to access the tools and race car class, but preventing anyone from modifying them.
    private readonly RaceCar _car = new();
    private readonly Tools _tools = new();
    public SetupController() { }
    public void ShowUI() //Main Menu Prototype. **Build in program then carry over to here**
    {
        VersionInfo();
        ProgramLoop();
    }
    private void VersionInfo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(AppInfo.Name);
        Console.WriteLine($"Version: {AppInfo.Version}");
        Console.ResetColor();
    }
    private void ProgramLoop()
    {
        bool endProgram = false;
        while (endProgram == false)
        {
            DisplayMainMenu();
            MenuOption choice = (MenuOption)ValidNumber();
            endProgram = MenuChoice(choice);
        }
    }
    private void DisplayMainMenu()
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
    private bool MenuChoice(MenuOption userInput)
    {
        switch (userInput)
        {
            case MenuOption.EnterSetup:
                {
                    _tools.BuildCar(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.FullSheet:
                {
                    DisplayFullSheet(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.Stagger:
                {
                    DisplayFrontStagger(_car);
                    DisplayRearStagger(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.Percentages:
                {
                    DisplayAllPercentages(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.RakeTilt:
                {
                    DisplayRake(_car);
                    DisplayTilt(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.Exit:
                {
                    return EndProgram();
                }
            default: //Bad key press
                {
                    InvalidInput();
                    break;
                }
        }
        return false;
    }
    private void DisplayFullSheet(RaceCar car)
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
    private void DisplayCarName(RaceCar car) => Console.WriteLine($"{car.GetCarName()}");
    private void DisplayAllPercentages(RaceCar car)
    {
        DisplayCrossWeight(car);
        DisplayLeftWeight(car);
        DisplayRearWeight(car);
    }
    private void DisplayTotalWeight(RaceCar car) => Console.WriteLine($"TOTAL WEIGHT: {car.TotalWeight:0.0} lbs.");
    private void DisplayCrossWeight(RaceCar car) => Console.WriteLine($"CROSS WEIGHT: {car.CrossWeightPercentage:0.00}%");
    private void DisplayLeftWeight(RaceCar car) => Console.WriteLine($"LEFT SIDE WEIGHT: {car.LeftSideWeightPercentage:0.00}%");
    private void DisplayRearWeight(RaceCar car) => Console.WriteLine($"REAR WEIGHT: {car.RearWeightPercentage:0.00}%");
    private void DisplayFrontStagger(RaceCar car) => Console.WriteLine($"FRONT STAGGER: {car.FrontStagger:0.00}\"");
    private void DisplayRearStagger(RaceCar car) => Console.WriteLine($"REAR STAGGER: {car.RearStagger:0.00}\"");
    private void DisplayRake(RaceCar car) => Console.WriteLine($"RAKE: {car.Rake:0.00}\""); //Negatives should be allowed here.    
    private void DisplayTilt(RaceCar car) => Console.WriteLine($"TILT: {car.Tilt:0.00}\""); //Negatives should be allowed her.   
    private void DisplayAllRideHeights(RaceCar car)
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
    private bool EndProgram()
    {
        Console.WriteLine("Have a good night!");
        AnyKey();
        return true;
    }
    private static void AnyKey()
    {
        Console.Write("Press ANY key to Continue: ");
        Console.ReadKey();
        Console.WriteLine();
    }
    private enum MenuOption
    {
        EnterSetup = 1,
        FullSheet = 2,
        Stagger = 3,
        Percentages = 4,
        RakeTilt = 5,
        Exit = 6,
    }
}
