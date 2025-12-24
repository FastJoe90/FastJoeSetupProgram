using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


public partial class CarViewModel : ObservableObject
{
    private readonly RaceCar _car = new();

    // Corner Weight Properties
    public string CarName { get => _car.CarName; set { _car.CarName = value; Refresh(); } }
    public float WeightLF { get => _car.GetCornerWeight(Corners.LF); set { _car.SetCornerWeight(Corners.LF, value); Refresh(); } }
    public float WeightRF { get => _car.GetCornerWeight(Corners.RF); set { _car.SetCornerWeight(Corners.RF, value); Refresh(); } }
    public float WeightLR { get => _car.GetCornerWeight(Corners.LR); set { _car.SetCornerWeight(Corners.LR, value); Refresh(); } }
    public float WeightRR { get => _car.GetCornerWeight(Corners.RR); set { _car.SetCornerWeight(Corners.RR, value); Refresh(); } }
    public float DiameterLF { get => _car.GetTireSize(Corners.LF); set { _car.SetTireSize(Corners.LF, value); Refresh(); } }
    public float DiameterRF { get => _car.GetTireSize(Corners.RF); set { _car.SetTireSize(Corners.RF, value); Refresh(); } }
    public float DiameterLR { get => _car.GetTireSize(Corners.LR); set { _car.SetTireSize(Corners.LR, value); Refresh(); } }
    public float DiameterRR { get => _car.GetTireSize(Corners.RR); set { _car.SetTireSize(Corners.RR, value); Refresh(); } }
    public float PressureLF { get => _car.GetTirePressure(Corners.LF); set { _car.SetTirePressure(Corners.LF, value); Refresh(); } }
    public float PressureRF { get => _car.GetTirePressure(Corners.RF); set { _car.SetTirePressure(Corners.RF, value); Refresh(); } }
    public float PressureLR { get => _car.GetTirePressure(Corners.LR); set { _car.SetTirePressure(Corners.LR, value); Refresh(); } }
    public float PressureRR { get => _car.GetTirePressure(Corners.RR); set { _car.SetTirePressure(Corners.RR, value); Refresh(); } }
    public float HeightLF { get => _car.GetTubeHeight(Corners.LF); set { _car.SetTubeHeight(Corners.LF, value); Refresh(); } }
    public float HeightRF { get => _car.GetTubeHeight(Corners.RF); set { _car.SetTubeHeight(Corners.RF, value); Refresh(); } }
    public float HeightLR { get => _car.GetTubeHeight(Corners.LR); set { _car.SetTubeHeight(Corners.LR, value); Refresh(); } }
    public float HeightRR { get => _car.GetTubeHeight(Corners.RR); set { _car.SetTubeHeight(Corners.RR, value); Refresh(); } }

    // Spring Rate Properties
    public float BarLF { get => _car.GetBarDiameter(Corners.LF); set { _car.SetBarDiameter(Corners.LF, value); Refresh(); } }
    public float BarRF { get => _car.GetBarDiameter(Corners.RF); set { _car.SetBarDiameter(Corners.RF, value); Refresh(); } }
    public float BarLR { get => _car.GetBarDiameter(Corners.LR); set { _car.SetBarDiameter(Corners.LR, value); Refresh(); } }
    public float BarRR { get => _car.GetBarDiameter(Corners.RR); set { _car.SetBarDiameter(Corners.RR, value); Refresh(); } }

    // Shock properties per corner
    public float ShockCompressionLF { get => _car.GetShock(Corners.LF).Compression; set { _car.GetShock(Corners.LF).Compression = value; Refresh(); } }
    public float ShockReboundLF { get => _car.GetShock(Corners.LF).Rebound; set { _car.GetShock(Corners.LF).Rebound = value; Refresh(); } }
    public int ShockClicksLF { get => _car.GetShock(Corners.LF).ReboundClicks; set { _car.GetShock(Corners.LF).ReboundClicks = value; Refresh(); } }
  

    public float ShockCompressionRF { get => _car.GetShock(Corners.RF).Compression; set { _car.GetShock(Corners.RF).Compression = value; Refresh(); } }
    public float ShockReboundRF { get => _car.GetShock(Corners.RF).Rebound; set { _car.GetShock(Corners.RF).Rebound = value; Refresh(); } }
    public int ShockClicksRF { get => _car.GetShock(Corners.RF).ReboundClicks; set { _car.GetShock(Corners.RF).ReboundClicks = value; Refresh(); } }
   

    public float ShockCompressionLR { get => _car.GetShock(Corners.LR).Compression; set { _car.GetShock(Corners.LR).Compression = value; Refresh(); } }
    public float ShockReboundLR { get => _car.GetShock(Corners.LR).Rebound; set { _car.GetShock(Corners.LR).Rebound = value; Refresh(); } }
    public int ShockClicksLR { get => _car.GetShock(Corners.LR).ReboundClicks; set { _car.GetShock(Corners.LR).ReboundClicks = value; Refresh(); } }
    

    public float ShockCompressionRR { get => _car.GetShock(Corners.RR).Compression; set { _car.GetShock(Corners.RR).Compression = value; Refresh(); } }
    public float ShockReboundRR { get => _car.GetShock(Corners.RR).Rebound; set { _car.GetShock(Corners.RR).Rebound = value; Refresh(); } }
    public int ShockClicksRR { get => _car.GetShock(Corners.RR).ReboundClicks; set { _car.GetShock(Corners.RR).ReboundClicks = value; Refresh(); } }
   

    // Commands to adjust clicks
    public System.Windows.Input.ICommand IncShockLF => new RelayCommand(() => { _car.GetShock(Corners.LF).IncrementClick(); Refresh(); });
    public System.Windows.Input.ICommand DecShockLF => new RelayCommand(() => { _car.GetShock(Corners.LF).DecrementClick(); Refresh(); });
    public System.Windows.Input.ICommand IncShockRF => new RelayCommand(() => { _car.GetShock(Corners.RF).IncrementClick(); Refresh(); });
    public System.Windows.Input.ICommand DecShockRF => new RelayCommand(() => { _car.GetShock(Corners.RF).DecrementClick(); Refresh(); });
    public System.Windows.Input.ICommand IncShockLR => new RelayCommand(() => { _car.GetShock(Corners.LR).IncrementClick(); Refresh(); });
    public System.Windows.Input.ICommand DecShockLR => new RelayCommand(() => { _car.GetShock(Corners.LR).DecrementClick(); Refresh(); });
    public System.Windows.Input.ICommand IncShockRR => new RelayCommand(() => { _car.GetShock(Corners.RR).IncrementClick(); Refresh(); });
    public System.Windows.Input.ICommand DecShockRR => new RelayCommand(() => { _car.GetShock(Corners.RR).DecrementClick(); Refresh(); });

    // Calculated Stats (Read-Only for the UI)
    public float TotalWeight => _car.TotalWeight;
    public float CrossWeightPercentage => CalculatePercentage(_car.CrossWeight);
    public float LeftSideWeightPercentage => CalculatePercentage(_car.LeftSideWeight);
    public float RearWeightPercentage => CalculatePercentage(_car.RearWeight);
    public float Tilt => _car.Tilt;
    public float Rake => _car.Rake;
    public float FrontStagger => _car.FrontStagger;
    public float RearStagger => _car.RearStagger;
    private string _statusMessage = string.Empty;
    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }
    private float CalculatePercentage(float subWeight)
    {
        float total = TotalWeight;
        return total > 0 ? (subWeight / total) * 100 : 0f;
    }
    public IAsyncRelayCommand SaveSetupCommand => new AsyncRelayCommand(SaveSetup);
    public IAsyncRelayCommand LoadSetupCommand => new AsyncRelayCommand(LoadSetup);
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
                sw.WriteLine($"--- TUBE HEIGHTS ---");
                sw.WriteLine($"LEFT FRONT: {HeightLF}\" | RIGHT FRONT: {HeightRF}\"");
                sw.WriteLine($"LEFT REAR:  {HeightLR}\" | RIGHT REAR:  {HeightRR}\"");
                sw.WriteLine();
                sw.WriteLine($"--- RAKE AND TILT ---");
                sw.WriteLine($"RAKE : {Rake:F2}\"");
                sw.WriteLine($"TILT : {Tilt:F2}\"");
                sw.WriteLine();

                // SPRING RATES
                sw.WriteLine($"--- TORSION BAR DIAMETER ---");
                sw.WriteLine($"LEFT FRONT: {BarLF} in | RIGHT FRONT: {BarRF} in");
                sw.WriteLine($"LEFT REAR:  {BarLR} in | RIGHT REAR:  {BarRR} in");
                sw.WriteLine();

                // SHOCK SETTINGS
                sw.WriteLine($"--- SHOCKS ---");
                sw.WriteLine($"LEFT FRONT: Compression: {ShockCompressionLF} | Rebound: {ShockReboundLF} | Clicks: {ShockClicksLF}");
                sw.WriteLine($"RIGHT FRONT: Compression: {ShockCompressionRF} | Rebound: {ShockReboundRF} | Clicks: {ShockClicksRF}");
                sw.WriteLine($"LEFT REAR: Compression: {ShockCompressionLR} | Rebound: {ShockReboundLR} | Clicks: {ShockClicksLR}");
                sw.WriteLine($"RIGHT REAR: Compression: {ShockCompressionRR} | Rebound: {ShockReboundRR} | Clicks: {ShockClicksRR}");
                sw.WriteLine();

                sw.WriteLine($"===================================================");
                sw.WriteLine($"NOTES: ");
                // You could add a Notes property later to fill this in!
            }

            StatusMessage = "✅ SETUP SAVED TO DISK";
            await Task.Delay(3000);
            StatusMessage = "";
        }
        catch (UnauthorizedAccessException)
        {
            StatusMessage = "❌ SAVE FAILED: Access denied";
            await Task.Delay(3000);
            StatusMessage = "";
        }
        catch (PathTooLongException)
        {
            StatusMessage = "❌ SAVE FAILED: File path too long";
            await Task.Delay(3000);
            StatusMessage = "";
        }
        catch (DirectoryNotFoundException)
        {
            StatusMessage = "❌ SAVE FAILED: Directory not found";
            await Task.Delay(3000);
            StatusMessage = "";
        }
        catch (IOException ex)
        {
            StatusMessage = "❌ SAVE FAILED: I/O error";
            System.Diagnostics.Debug.WriteLine(ex.ToString());
            await Task.Delay(3000);
            StatusMessage = "";
        }
        catch (Exception ex)
        {
            StatusMessage = "❌ SAVE FAILED";
            System.Diagnostics.Debug.WriteLine(ex.ToString());
            await Task.Delay(3000);
            StatusMessage = "";
        }
    }

    // Replace LoadSetup method with corrected, robust parsing and error handling
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
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (line.StartsWith("---")) { currentSection = line; continue; }

                    if (line.Contains("SETUP NAME :"))
                    {
                        CarName = line.Split(':').Last().Trim();
                        continue;
                    }

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
                    else if (currentSection.Contains("TUBE HEIGHTS") || currentSection.Contains("TUBE HEIGHT"))
                    {
                        if (line.Contains("LEFT FRONT:")) HeightLF = ExtractDoubleValue(line, "LEFT FRONT:", "\"");
                        if (line.Contains("RIGHT FRONT:")) HeightRF = ExtractDoubleValue(line, "RIGHT FRONT:", "\"");
                        if (line.Contains("LEFT REAR:")) HeightLR = ExtractDoubleValue(line, "LEFT REAR:", "\"");
                        if (line.Contains("RIGHT REAR:")) HeightRR = ExtractDoubleValue(line, "RIGHT REAR:", "\"");
                    }
                    else if (currentSection.Contains("TORSION BAR DIAMETER") || currentSection.Contains("BAR DIAMETER"))
                    {
                        // Torsion bar diameter saved in inches
                        if (line.Contains("LEFT FRONT:")) BarLF = ExtractDoubleValue(line, "LEFT FRONT:", "in");
                        if (line.Contains("RIGHT FRONT:")) BarRF = ExtractDoubleValue(line, "RIGHT FRONT:", "in");
                        if (line.Contains("LEFT REAR:")) BarLR = ExtractDoubleValue(line, "LEFT REAR:", "in");
                        if (line.Contains("RIGHT REAR:")) BarRR = ExtractDoubleValue(line, "RIGHT REAR:", "in");
                    }
                    else if (currentSection.Contains("SHOCKS"))
                    {
                        // shock lines: parse compression, reboundbase, clicks from the summary lines
                        if (line.Contains("LEFT FRONT:"))
                        {
                            ShockCompressionLF = ExtractDoubleValue(line, "Compression:", "|");
                            ShockReboundLF = ExtractDoubleValue(line, "ReboundBase:", "|");
                            ShockClicksLF = ExtractIntValue(line, "Clicks:", "|");
                        }

                        if (line.Contains("RIGHT FRONT:"))
                        {
                            ShockCompressionRF = ExtractDoubleValue(line, "Compression:", "|");
                            ShockReboundRF = ExtractDoubleValue(line, "ReboundBase:", "|");
                            ShockClicksRF = ExtractIntValue(line, "Clicks:", "|");
                        }

                        if (line.Contains("LEFT REAR:"))
                        {
                            ShockCompressionLR = ExtractDoubleValue(line, "Compression:", "|");
                            ShockReboundLR = ExtractDoubleValue(line, "ReboundBase:", "|");
                            ShockClicksLR = ExtractIntValue(line, "Clicks:", "|");
                        }

                        if (line.Contains("RIGHT REAR:"))
                        {
                            ShockCompressionRR = ExtractDoubleValue(line, "Compression:", "|");
                            ShockReboundRR = ExtractDoubleValue(line, "ReboundBase:", "|");
                            ShockClicksRR = ExtractIntValue(line, "Clicks:", "|");
                        }
                    }
                }

                Refresh();
                StatusMessage = "📂 SETUP LOADED";
                await Task.Delay(3000);
                StatusMessage = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                StatusMessage = "❌ LOAD ERROR";
                await Task.Delay(3000);
                StatusMessage = "";
            }
        }
    }

    // Improved helper to grab the number between a label and a unit
    private float ExtractDoubleValue(string line, string label, string unit)
    {
        try
        {
            int start = line.IndexOf(label) + label.Length;
            int end = (string.IsNullOrEmpty(unit)) ? line.Length : line.IndexOf(unit, start);
            if (end < 0) end = line.Length;
            string valPart = line.Substring(start, end - start).Trim();
            return float.Parse(valPart);
        }
        catch { return 0; }
    }

    private int ExtractIntValue(string line, string label, string unit)
    {
        try
        {
            int start = line.IndexOf(label) + label.Length;
            int end = (string.IsNullOrEmpty(unit)) ? line.Length : line.IndexOf(unit, start);
            if (end < 0) end = line.Length;
            string valPart = line.Substring(start, end - start).Trim();
            return int.Parse(valPart);
        }
        catch { return 0; }
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
        OnPropertyChanged(nameof(BarLF));
        OnPropertyChanged(nameof(BarRF));
        OnPropertyChanged(nameof(BarLR));
        OnPropertyChanged(nameof(BarRR));
        OnPropertyChanged(nameof(ShockCompressionLF));
        OnPropertyChanged(nameof(ShockReboundLF));
        OnPropertyChanged(nameof(ShockClicksLF));
        OnPropertyChanged(nameof(ShockReboundLF));
        OnPropertyChanged(nameof(ShockCompressionRF));
        OnPropertyChanged(nameof(ShockReboundRF));
        OnPropertyChanged(nameof(ShockClicksRF));
        OnPropertyChanged(nameof(ShockReboundRF));
        OnPropertyChanged(nameof(ShockCompressionLR));
        OnPropertyChanged(nameof(ShockReboundLR));
        OnPropertyChanged(nameof(ShockClicksLR));
        OnPropertyChanged(nameof(ShockReboundLR));
        OnPropertyChanged(nameof(ShockCompressionRR));
        OnPropertyChanged(nameof(ShockReboundRR));
        OnPropertyChanged(nameof(ShockClicksRR));
        OnPropertyChanged(nameof(ShockReboundRR));

        // Calculated stats
        OnPropertyChanged(nameof(TotalWeight));
        OnPropertyChanged(nameof(CrossWeightPercentage));
        OnPropertyChanged(nameof(LeftSideWeightPercentage));
        OnPropertyChanged(nameof(RearWeightPercentage));
        OnPropertyChanged(nameof(FrontStagger));
        OnPropertyChanged(nameof(RearStagger));
        OnPropertyChanged(nameof(Tilt));
        OnPropertyChanged(nameof(Rake));
    }
}