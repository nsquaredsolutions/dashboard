using nsquared.dashboard.api;
namespace SimpleLayout;

public class Layout : ILayout
{
    public string Name { get; set; } = "Simple Layout";

    public List<IComponent> Components { get; set; } = new List<IComponent>();

    public void Load()
    {
        // Load components here
        Components.Add(new BackgroundComponent());
    }
}