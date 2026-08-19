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
            Top = 12,
            Left = 12,
            Bottom = 12,
            Right = 12
        };
        Size = new ComponentSize
        {
            Width = 320,
            Height = 160
        };
    }
}
