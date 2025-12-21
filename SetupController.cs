public class SetupController
{
    //Allowing the UI to access the tools and race car class, but preventing anyone from modifying them.
    private readonly RaceCar _car = new();    
    public SetupController() { }
    public void StartProgram() //Main Menu Prototype. **Build in program then carry over to here**
    {
        UI.VersionInfo(); 
        ProgramLoop();
    }   
    private void ProgramLoop() // For Console UI version.
    {        
        bool endProgram = false;
        while (endProgram == false)
        {
            UI.DisplayMainMenu();
            MenuOption choice = (MenuOption)UI.GetValidInt();
            endProgram = HandleMenuChoice(choice);
        }
    }
    private void BuildCar() //Creates a new RaceCar object with user set values.
    {
        SetCarName();
        SetTirePressures();
        SetTireSizes();
        SetCornerWeights();
        SetFrameHeight();
    }
    private void SetCarName() 
    {
        _car.CarName = (UI.AskCarName());
    }
    private void SetTireSizes()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireDiameter = UI.AskTireDiameter(tirePosition);
            _car.SetTireSize(carCorner, tireDiameter);
        }
    }
    private void SetTirePressures()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tirePressure = UI.AskTirePressure(tirePosition);
            _car.SetTirePressure(carCorner, tirePressure);
        }
    }
    private void SetCornerWeights()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireWeight = UI.AskCornerWeight(tirePosition);
            _car.SetCornerWeight(carCorner, tireWeight);
        }
    }
    private void SetFrameHeight()
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float frameHeight = UI.AskFrameHeight(tirePosition);
            _car.SetFrameHeight(carCorner, frameHeight);
        }
    }     
    private bool HandleMenuChoice(MenuOption userInput)
    {
        switch (userInput)
        {
            case MenuOption.EnterSetup:
                {
                    BuildCar();
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.DisplayFullSetup:
                {
                    UI.DisplayFullSetup(_car);
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.DisplayTireInfo:
                {
                    UI.ShowAllTirePressures(_car);
                    UI.ShowFrontStagger(_car);
                    UI.ShowRearStagger(_car);
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.DisplayPercentages:
                {
                    UI.ShowAllPercentages(_car);
                    UI.PressAnyKey();
                    break;
                }
            case MenuOption.DisplayRakeTilt:
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
        DisplayFullSetup = 2,
        DisplayTireInfo = 3,
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
