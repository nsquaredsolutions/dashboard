using nsquared.dashboard.api;
namespace SimpleLayout;

public class Layout : ILayout
{
    public string Name => "Simple Layout";

    public List<IComponent> Components { get; } = new List<IComponent>();

    public void Load()
    {
        // Load components here
    }
}