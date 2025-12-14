public class SetupController
{
    //Allowing the UI to access the tools and race car class, but preventing anyone from modifying them.
    private readonly RaceCar _car = new();
    
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
            UI.DisplayMainMenu();
            MenuOption choice = (MenuOption)ValidNumber();
            endProgram = MenuChoice(choice);
        }
    }
    public void BuildCar(RaceCar userCar) //Creates a new RaceCar object with user set values.
    {
        AskCarName(userCar);
        AskTireSizes(userCar);
        AskCornerWeights(userCar);
        AskFrameHeight(userCar);
    }
    private void AskCarName(RaceCar userCar)
    {
        string userInput = UserInput("Please enter the TYPE of car you are working on");
        userCar.SetCarName(userInput);
    }
    private void AskTireSizes(RaceCar userCar)
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireDiameter = ValidNumber($"Enter {tirePosition} Tire Size: ");
            userCar.SetTireSize(carCorner, tireDiameter);
        }
    }
    private void AskCornerWeights(RaceCar userCar)
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireWeight = ValidNumber($"Enter {tirePosition} Corner Weight: ");
            userCar.SetCornerWeight(carCorner, tireWeight);
        }
    }
    private void AskFrameHeight(RaceCar userCar)
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float frameHeight = ValidNumber($"Enter {tirePosition} Frame Height: ");
            userCar.SetFrameHeight(carCorner, frameHeight);
        }
    }     
    private bool MenuChoice(MenuOption userInput)
    {
        switch (userInput)
        {
            case MenuOption.EnterSetup:
                {
                    BuildCar(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.DisplayFullSetup:
                {
                    UI.DisplayFullSetup(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.DisplayStagger:
                {
                    UI.DisplayFrontStagger(_car);
                    UI.DisplayRearStagger(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.DisplayPercentages:
                {
                    UI.DisplayAllPercentages(_car);
                    AnyKey();
                    break;
                }
            case MenuOption.DisplayRakeTilt:
                {
                    UI.DisplayRake(_car);
                    UI.DisplayTilt(_car);
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
        DisplayFullSetup = 2,
        DisplayStagger = 3,
        DisplayPercentages = 4,
        DisplayRakeTilt = 5,
        Exit = 6,
    }
    private static readonly (Corner corner, string label)[] Corners =
     {
        (Corner.LF, "Left Front"),
        (Corner.RF, "Right Front"),
        (Corner.LR, "Left Rear"),
        (Corner.RR, "Right Rear"),

    };
}
