using nsquared.dashboard.api;

namespace SimpleComponent;

public class ClockComponent : IComponent
{
    public string AssemblyFile => "SimpleComponent.Component";
    public string TypeName => "SimpleComponent.ClockComponentControl";
    public string Name { get; } = "Clock";
    public ComponentMargin Margin { get; set; }
    public ComponentSize Size { get; set; }
    public ComponentVerticalAlignment VerticalAlignment { get; set; }
    public ComponentHorizontalAlignment HorizontalAlignment { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }

    public ClockComponent()
    {
        VerticalAlignment = ComponentVerticalAlignment.Center;
        HorizontalAlignment = ComponentHorizontalAlignment.Center;
        Margin = new ComponentMargin
        {
            Top = 0,
            Left = 0,
            Bottom = 0,
            Right = 0
        };
        Size = new ComponentSize
        {
            Width = double.NaN, // Auto width
            Height = double.NaN // Auto height
        };
    }
}
