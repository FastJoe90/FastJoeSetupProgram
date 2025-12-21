using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;

using System.Windows.Input;

public class CarViewModel : INotifyPropertyChanged
{
    private readonly RaceCar _car = new();   

    // Corner Weight Properties
    public string CarName { get => _car.CarName; set { _car.CarName = value; Refresh(); } }
    public float WeightLF { get => _car.GetCornerWeight(Corner.LF); set { _car.SetCornerWeight(Corner.LF, value); Refresh(); } }
    public float WeightRF { get => _car.GetCornerWeight(Corner.RF); set { _car.SetCornerWeight(Corner.RF, value); Refresh(); } }
    public float WeightLR { get => _car.GetCornerWeight(Corner.LR); set { _car.SetCornerWeight(Corner.LR, value); Refresh(); } }
    public float WeightRR { get => _car.GetCornerWeight(Corner.RR); set { _car.SetCornerWeight(Corner.RR, value); Refresh(); } }
    public float DiameterLF { get => _car.GetTireSize(Corner.LF); set { _car.SetTireSize(Corner.LF, value); Refresh(); } }
    public float DiameterRF { get => _car.GetTireSize(Corner.RF); set { _car.SetTireSize(Corner.RF, value); Refresh(); } }
    public float DiameterLR { get => _car.GetTireSize(Corner.LR); set { _car.SetTireSize(Corner.LR, value); Refresh(); } }
    public float DiameterRR { get => _car.GetTireSize(Corner.RR); set { _car.SetTireSize(Corner.RR, value); Refresh(); } }
    public float PressureLF { get => _car.GetTirePressure(Corner.LF); set { _car.SetTirePressure(Corner.LF, value); Refresh(); } }
    public float PressureRF { get => _car.GetTirePressure(Corner.RF); set { _car.SetTirePressure(Corner.RF, value); Refresh(); } }
    public float PressureLR { get => _car.GetTirePressure(Corner.LR); set { _car.SetTirePressure(Corner.LR, value); Refresh(); } }
    public float PressureRR { get => _car.GetTirePressure(Corner.RR); set { _car.SetTirePressure(Corner.RR, value); Refresh(); } }
    public float HeightLF { get => _car.GetFrameHeight(Corner.LF); set { _car.SetFrameHeight(Corner.LF, value); Refresh(); } }
    public float HeightRF { get => _car.GetFrameHeight(Corner.RF); set { _car.SetFrameHeight(Corner.RF, value); Refresh(); } }
    public float HeightLR { get => _car.GetFrameHeight(Corner.LR); set { _car.SetFrameHeight(Corner.LR, value); Refresh(); } }
    public float HeightRR { get => _car.GetFrameHeight(Corner.RR); set { _car.SetFrameHeight(Corner.RR, value); Refresh(); } }

    // Calculated Stats (Read-Only for the UI)
    public float TotalWeight => _car.TotalWeight;
    public float CrossWeightPercentage => CalculatePercentage(_car.CrossWeight);
    public float LeftSideWeightPercentage => CalculatePercentage(_car.LeftSideWeight);
    public float RearWeightPercentage => CalculatePercentage(_car.RearWeight);
    public float Tilt => _car.Tilt;
    public float Rake => _car.Rake;
    public float FrontStagger => _car.FrontStagger;
    public float RearStagger => _car.RearStagger;
    private string _statusMessage;
    public string StatusMessage
    {
        get => _statusMessage;
        set { _statusMessage = value; OnPropertyChanged(); }
    }
    private float CalculatePercentage(float subWeight)
    {
        float total = TotalWeight;
        return total > 0 ? (subWeight / total) * 100 : 0f;
    }
    public ICommand SaveSetupCommand => new RelayCommand(async () => await SaveSetup());
    public ICommand LoadSetupCommand => new RelayCommand(async () => await LoadSetup());
    private async Task SaveSetup()
    {
        try
        {
            // 1. Create the file name (sanitized)
            string fileName = string.IsNullOrWhiteSpace(CarName) ? "Untitled" : CarName;
            foreach (char c in Path.GetInvalidFileNameChars()) fileName = fileName.Replace(c, '_');
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.txt");

            // 2. Write the data
            using (StreamWriter sw = new StreamWriter(path))
            {
                // HEADER
                sw.WriteLine($"===================================================");
                sw.WriteLine($"   FAST JOE'S DIGITAL CREW CHIEF - SETUP SHEET    ");
                sw.WriteLine($"===================================================");
                sw.WriteLine($"SETUP NAME : {CarName}");
                sw.WriteLine($"DATE/TIME  : {DateTime.Now:f}");
                sw.WriteLine();

                // SECTION 1:WEIGHTS
                sw.WriteLine($"--- CHASSIS WEIGHTS ---");
                sw.WriteLine($"TOTAL WEIGHT : {TotalWeight} lbs");
                sw.WriteLine($"CROSS WEIGHT : {CrossWeightPercentage:F2}%");
                sw.WriteLine($"LEFT SIDE    : {LeftSideWeightPercentage:F2}%");
                sw.WriteLine($"REAR WEIGHT  : {RearWeightPercentage:F2}%");
                sw.WriteLine($"LEFT FRONT: {WeightLF} lbs.| RIGHT FRONT: {WeightRF} lbs.");
                sw.WriteLine($"LEFT REAR:  {WeightLR} lbs.| RIGHT REAR:  {WeightRR} lbs.");
                sw.WriteLine();

                // SECTION 2: TIRE INFO
                sw.WriteLine($"--- TIRE PRESSURES ---");
                sw.WriteLine($"LEFT FRONT: {PressureLF}\" | RIGHT FRONT: {PressureRF}\"");
                sw.WriteLine($"LEFT REAR:  {PressureLR}\" | RIGHT REAR:  {PressureRR}\"");
                sw.WriteLine();
                sw.WriteLine($"--- TIRE SIZE ---");
                sw.WriteLine($"LEFT FRONT: {DiameterLF}\" | RIGHT FRONT: {DiameterRF}\"");
                sw.WriteLine($"LEFT REAR:  {DiameterLR}\" | RIGHT REAR:  {DiameterRR}\"");
                sw.WriteLine();
                sw.WriteLine($"--- STAGGER ---");
                sw.WriteLine($"FRONT STAGGER: {FrontStagger:F2}\"");
                sw.WriteLine($"REAR STAGGER : {RearStagger:F2}\"");
                sw.WriteLine();

                // SECTION 3 : CHASSIS DETAILS
                sw.WriteLine($"--- FRAME HEIGHTS ---");
                sw.WriteLine($"LEFT FRONT: {HeightLF}\" | RIGHT FRONT: {HeightRF}\"");
                sw.WriteLine($"LEFT REAR:  {HeightLR}\" | RIGHT REAR:  {HeightRR}\"");
                sw.WriteLine();
                sw.WriteLine($"--- RAKE AND TILT ---");
                sw.WriteLine($"RAKE : {Rake:F2}\"");
                sw.WriteLine($"TILT : {Tilt:F2}\"");
                sw.WriteLine();               

                sw.WriteLine($"===================================================");
                sw.WriteLine($"NOTES: ");
                // You could add a Notes property later to fill this in!
            }

            StatusMessage = "✅ SETUP SAVED TO DISK";
            await Task.Delay(3000);
            StatusMessage = "";
        }
        catch (Exception ex)
        {
            StatusMessage = "❌ SAVE FAILED";
        }
    }

    private async Task LoadSetup()
    {
        var openFileDialog = new Microsoft.Win32.OpenFileDialog { Filter = "Text files (*.txt)|*.txt" };

        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                string currentSection = "";

                foreach (string line in lines)
                {
                    if (line.StartsWith("---")) { currentSection = line; continue; }
                    if (line.Contains("SETUP NAME :")) CarName = line.Split(':').Last().Trim();

                    // Parsing logic based on which section we are currently in
                    if (currentSection.Contains("CHASSIS WEIGHTS"))
                    {
                        if (line.Contains("LEFT FRONT:")) WeightLF = ExtractDoubleValue(line, "LEFT FRONT:", "lbs");
                        if (line.Contains("RIGHT FRONT:")) WeightRF = ExtractDoubleValue(line, "RIGHT FRONT:", "lbs");
                        if (line.Contains("LEFT REAR:")) WeightLR = ExtractDoubleValue(line, "LEFT REAR:", "lbs");
                        if (line.Contains("RIGHT REAR:")) WeightRR = ExtractDoubleValue(line, "RIGHT REAR:", "lbs");
                    }
                    else if (currentSection.Contains("TIRE PRESSURES"))
                    {
                        if (line.Contains("LEFT FRONT:")) PressureLF = ExtractDoubleValue(line, "LEFT FRONT:", "\"");
                        if (line.Contains("RIGHT FRONT:")) PressureRF = ExtractDoubleValue(line, "RIGHT FRONT:", "\"");
                        if (line.Contains("LEFT REAR:")) PressureLR = ExtractDoubleValue(line, "LEFT REAR:", "\"");
                        if (line.Contains("RIGHT REAR:")) PressureRR = ExtractDoubleValue(line, "RIGHT REAR:", "\"");
                    }
                    else if (currentSection.Contains("TIRE SIZE"))
                    {
                        if (line.Contains("LEFT FRONT:")) DiameterLF = ExtractDoubleValue(line, "LEFT FRONT:", "\"");
                        if (line.Contains("RIGHT FRONT:")) DiameterRF = ExtractDoubleValue(line, "RIGHT FRONT:", "\"");
                        if (line.Contains("LEFT REAR:")) DiameterLR = ExtractDoubleValue(line, "LEFT REAR:", "\"");
                        if (line.Contains("RIGHT REAR:")) DiameterRR = ExtractDoubleValue(line, "RIGHT REAR:", "\"");
                    }
                    else if (currentSection.Contains("FRAME HEIGHTS"))
                    {
                        if (line.Contains("LEFT FRONT:")) HeightLF = ExtractDoubleValue(line, "LEFT FRONT:", "\"");
                        if (line.Contains("RIGHT FRONT:")) HeightRF = ExtractDoubleValue(line, "RIGHT FRONT:", "\"");
                        if (line.Contains("LEFT REAR:")) HeightLR = ExtractDoubleValue(line, "LEFT REAR:", "\"");
                        if (line.Contains("RIGHT REAR:")) HeightRR = ExtractDoubleValue(line, "RIGHT REAR:", "\"");
                    }
                }

                Refresh();
                StatusMessage = "📂 SETUP LOADED";
                await Task.Delay(3000);
                StatusMessage = "";
            }
            catch { StatusMessage = "❌ LOAD ERROR"; }
        }
    }

    // Improved helper to grab the number between a label and a unit
    private float ExtractDoubleValue(string line, string label, string unit)
    {
        try
        {
            int start = line.IndexOf(label) + label.Length;
            int end = line.IndexOf(unit, start);
            string valPart = line.Substring(start, end - start).Trim();
            return float.Parse(valPart);
        }
        catch { return 0; }
    }



    // Simple RelayCommand helper (Put this at the bottom of your file or in a new file)
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        public RelayCommand(Action execute) => _execute = execute;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute();
        public event EventHandler CanExecuteChanged;
    }
    private void Refresh()
    {
        OnPropertyChanged(nameof(CarName));
        OnPropertyChanged(nameof(WeightLF));
        OnPropertyChanged(nameof(WeightRF));
        OnPropertyChanged(nameof(WeightLR));
        OnPropertyChanged(nameof(WeightRR));
        OnPropertyChanged(nameof(DiameterLF));
        OnPropertyChanged(nameof(DiameterRF));
        OnPropertyChanged(nameof(DiameterLR));
        OnPropertyChanged(nameof(DiameterRR));
        OnPropertyChanged(nameof(PressureLF));
        OnPropertyChanged(nameof(PressureRF));
        OnPropertyChanged(nameof(PressureLR));
        OnPropertyChanged(nameof(PressureRR));
        OnPropertyChanged(nameof(HeightLF));
        OnPropertyChanged(nameof(HeightRF));
        OnPropertyChanged(nameof(HeightLR));
        OnPropertyChanged(nameof(HeightRR));
        OnPropertyChanged(nameof(TotalWeight));
        OnPropertyChanged(nameof(CrossWeightPercentage));
        OnPropertyChanged(nameof(FrontStagger));
        OnPropertyChanged(nameof(RearStagger));
        OnPropertyChanged(nameof(LeftSideWeightPercentage));
        OnPropertyChanged(nameof(RearWeightPercentage));
        OnPropertyChanged(nameof(Tilt));
        OnPropertyChanged(nameof(Rake));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}