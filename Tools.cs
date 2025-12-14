
public class Tools
{

    public void BuildCar(RaceCar car) //Creates a new RaceCar object with user set values.
    {
        SetCarName(car);
        SetTireSizes(car);
        SetCornerWeights(car);
        SetFrameHeight(car);

    }
    public void SetCarName(RaceCar car)
    {
        string userInput = UserInput("Please enter the TYPE of car you are working on");
        car.SetCarName(userInput);
    }
    public void SetTireSizes(RaceCar car)
    {
        string[] corner = new[] { "Left Front", "Right Front", "Left Rear", "Right Rear" };
        for (int position = 0; position < corner.Length; position++)
        {
            float tireDiameter = ValidNumber($"Enter {corner[position]} Tire Size");
            car.SetTireSizeOne((Corner)position, tireDiameter);
        }
    }
    public void SetCornerWeights(RaceCar car)
    {
        string[] corner = new[] { "Left Front", "Right Front", "Left Rear", "Right Rear" };
        for (int position = 0; position < corner.Length; position++)
        {
            float tireWeight = ValidNumber($"Enter {corner[position]} Corner Weight");
            car.SetCornerWeightOne((Corner)position, tireWeight);
        }

    }
    public void SetFrameHeight(RaceCar car)
    {
        string[] corner = new[] { "Left Front", "Right Front", "Left Rear", "Right Rear" };
        for (int position = 0; position < corner.Length; position++)
        {
            float frameHeight = ValidNumber($"Enter {corner[position]} Frame Height");
            car.SetFrameHeightOne((Corner)position, frameHeight);
        }
    }
    public static float ValidNumber(string inputMessage) //Input validation method.
    {
        while (true)
        {
            Console.Write($"Enter {inputMessage}: ");
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float number))
            {
                return number;
            }
            else
            {
                InvalidNumber();
            }
        }
    }

    private static void InvalidNumber()
    {
        Console.WriteLine("Not a valid number! Press ANY key to continue.");
        Console.ReadKey();
    }

    public static string UserInput(string inputMessage)
    {
        Console.WriteLine(inputMessage);
        return Console.ReadLine();

    }
}