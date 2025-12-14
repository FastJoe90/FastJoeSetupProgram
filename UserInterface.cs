public class UserInterface
{
     //Allowing the UI to access my Tools (Methods)
    public UserInterface()
    {
    
    }
    public void ShowUI(RaceCar car, Tools tools) //Main Menu Prototype. **Build in program then carry over to here**
    {
        WelcomeMessage();
        //Building car.
        tools.BuildCar(car);
        //Displaying results.
        car.DisplayCarName();
        car.DisplayFrontStagger();
        car.DisplayRearStagger();
        car.DisplayAllPercentages();
        car.DisplayAllRideHeights();
        car.DisplayRake();
        car.DisplayTilt();
       
    }
    public void WelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Fast Joe's: Digital Crew Chief");
        Console.WriteLine("Version 0.0.1");
        Console.ResetColor();
    }

  
}
