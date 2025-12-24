public class CarCorner
{
    public Tire Wheel { get; set; } = new Tire();
    public Shock Shock { get; set; } = new Shock();
    public float WheelSpacing { get; private set; } = 0;
    public float Weight { get; set; } //In pounds
    public float TubeHeight { get; set; } //In Inches
    public float BarDiameter { get; set; } //In Inches.
    private float SpacerSize { get; init; } = 0.25f; //Typical race car wheel spacers are 1/4 inch.
   
   
    public void SetWheelSpacing(float spacing) => WheelSpacing = Math.Max(0, spacing);
    public void AddSpacer() => WheelSpacing = Math.Max(0, WheelSpacing + SpacerSize);
    public void RemoveSpacer() => WheelSpacing = Math.Max(0, WheelSpacing - SpacerSize);


}
