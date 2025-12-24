public class CarCorner
{
    public Tire Tire { get; set; } = new Tire();
    public Shock Shock { get; set; } = new Shock();
    public float WheelSpacing { get; set; } = 0f;
    public float Weight { get; set; } //In pounds
    public float TubeHeight { get; set; } //In Inches
    public float BarDiameter { get; set; } //In Inches.
    private float SpacerSize { get; init; } = 0.25f; //Typical race car wheel spacers are 1/4 inch. **NEEDS IMPLEMENTED**

    //Needs implemented.

    public void SetSpacing(float spacing) => WheelSpacing = Math.Max(0, spacing); 
    public void AddSpacer() => WheelSpacing = Math.Max(0, WheelSpacing + SpacerSize);
    public void RemoveSpacer() => WheelSpacing = Math.Max(0, WheelSpacing - SpacerSize);

}
