public class Orchestrator //ONLY USED FOR CONSOLE VERSION
{
    //Allowing the UI to access the tools and race car class, but preventing anyone from modifying them.
    private readonly RaceCar _car = new();    
    public Orchestrator() { }
    public void StartProgram() //Console Program Start
    {
        UI.VersionInfo(); 
        ConsoleLoop();
    }   
    private void ConsoleLoop() // For Console UI version.
    {        
        bool endProgram = false;
        while (endProgram == false)
        {
            UI.DisplayMainMenu();
            MenuOption choice = (MenuOption)UI.GetValidInt();
            endProgram = MenuChoice(choice);
        }
    }
    private void CreateUserCar() //Creates a new RaceCar object with user set values.
    {
        ChangeCarName();
        ChangeTirePressures();
        ChangeTireSizes();
        ChangeCornerWeights();
        ChangeFrameHeights();
    }
    private void ChangeCarName() 
    {
        _car.CarName = (UI.AskCarName());
    }
    private void ChangeTireSizes()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireDiameter = UI.AskTireDiameter(tirePosition);
            _car.SetTireSize(carCorner, tireDiameter);
        }
    }
    private void ChangeTirePressures()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tirePressure = UI.AskTirePressure(tirePosition);
            _car.SetTirePressure(carCorner, tirePressure);
        }
    }
    private void ChangeCornerWeights()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireWeight = UI.AskCornerWeight(tirePosition);
            _car.SetCornerWeight(carCorner, tireWeight);
        }
    }
    private void ChangeFrameHeights()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float frameHeight = UI.AskFrameHeight(tirePosition);
            _car.SetFrameHeight(carCorner, frameHeight);
        }
    }     
    private bool MenuChoice(MenuOption userInput)
    {
        switch (userInput)
        {
            case MenuOption.EnterSetup:
                {
                    CreateUserCar();
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.FullSetup:
                {
                    UI.DisplayFullSetup(_car);
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.TireInfo:
                {
                    UI.ShowAllTirePressures(_car);
                    UI.ShowFrontStagger(_car);
                    UI.ShowRearStagger(_car);
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.Percentages:
                {
                    UI.ShowAllPercentages(_car);
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.RakeTilt:
                {
                    UI.ShowRake(_car);
                    UI.ShowTilt(_car);
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.Exit:
                {
                    return UI.EndProgram();
                }
            default: //Bad key press
                {
                    UI.InvalidInput();
                    break;
                }            
        }       
        return false;
    }      
    private enum MenuOption
    {
        EnterSetup = 1,
        FullSetup = 2,
        TireInfo = 3,
        Percentages = 4,
        RakeTilt = 5,
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
