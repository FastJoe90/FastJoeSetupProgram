
public class Tools
{
    public void BuildCar(RaceCar userCar) //Creates a new RaceCar object with user set values.
    {
        AskCarName(userCar);
        AskTireSizes(userCar);
        AskCornerWeights(userCar);
        AskFrameHeight(userCar);
    }
    private void AskCarName(RaceCar userCar)
    {
        string userInput = UserInterface.UserInput("Please enter the TYPE of car you are working on");
        userCar.SetCarName(userInput);
    }
    private void AskTireSizes(RaceCar userCar)
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireDiameter = UserInterface.ValidNumber($"Enter {tirePosition} Tire Size: ");
            userCar.SetTireSize(carCorner, tireDiameter);
        }
    }
    private void AskCornerWeights(RaceCar userCar)
    {
        foreach (var (carCorner, tirePosition) in Corners)
        {
            float tireWeight = UserInterface.ValidNumber($"Enter {tirePosition} Corner Weight: ");
            userCar.SetCornerWeight(carCorner, tireWeight);
        }
    }
    private void AskFrameHeight(RaceCar userCar)
    {

        foreach (var (carCorner, tirePosition) in Corners)
        {
            float frameHeight = UserInterface.ValidNumber($"Enter {tirePosition} Frame Height: ");
            userCar.SetFrameHeight(carCorner, frameHeight);
        }
    }
    private static readonly (Corner corner, string label)[] Corners =
     {
        (Corner.LF, "Left Front"),
        (Corner.RF, "Right Front"),
        (Corner.LR, "Left Rear"),
        (Corner.RR, "Right Rear"),

    };
}