using nsquared.dashboard.api;

public class BackgroundComponent : IComponent
{
    public string AssemblyFile => "SimpleLayout.Layout";
    public string TypeName => "SimpleLayout.BackgroundComponentControl";
    public string Name { get; } = "Simple Layout";
    public ComponentMargin Margin { get; set; }
    public ComponentSize Size { get; set; }
    public ComponentVerticalAlignment VerticalAlignment { get; set; }
    public ComponentHorizontalAlignment HorizontalAlignment { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }

    public BackgroundComponent()
    {
        VerticalAlignment = ComponentVerticalAlignment.Stretch;
        HorizontalAlignment = ComponentHorizontalAlignment.Stretch;
        Margin = new ComponentMargin
        {
            Top = 0,
            Left = 0,
            Bottom = 0,
            Right = 0
        };
        Size = new ComponentSize
        {
            Width = 1920,
            Height = 1080
        };
    }
}