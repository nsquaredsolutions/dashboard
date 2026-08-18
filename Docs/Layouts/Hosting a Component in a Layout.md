# Hosting a Component in a Layout for nsquared dashboard

This guide shows how to take the sample `SimpleLayout` project and add a `SimpleComponent` to the layout. In nsquared dashboard, the layout is the host and the component is the reusable visual element that gets added to the layout's `Components` list.

## Start from the sample layout

The sample layout already follows the correct pattern:

```cs
using nsquared.dashboard.api;
namespace SimpleLayout;

public class Layout : ILayout
{
    public string Name { get; set; } = "Simple Layout";

    public List<IComponent> Components { get; set; } = new List<IComponent>();

    public void Load()
    {
        Components.Add(new BackgroundComponent());
    }
}
```

This is the key idea: a layout owns a list of `IComponent` objects and fills that list in its `Load()` method.

## Add the component namespace

If your component is in a separate assembly, add the namespace reference at the top of the layout file.

```cs
using nsquared.dashboard.api;
using SimpleComponent;
```

If the component is in the same project, you can skip the `using` and reference the class directly.

## Add the component to the layout

Update the `Load()` method so it adds the `SimpleComponent` alongside the background component.

```cs
using nsquared.dashboard.api;
using SimpleComponent;

namespace SimpleLayout;

public class Layout : ILayout
{
    public string Name { get; set; } = "Simple Layout";

    public List<IComponent> Components { get; set; } = new List<IComponent>();

    public void Load()
    {
        Components.Add(new BackgroundComponent());
        Components.Add(new SimpleComponent());
    }
}
```

This tells the dashboard to instantiate both visual elements when the layout loads.

## Example component metadata

Your component should implement `IComponent` and describe where it should appear on the screen.

```cs
using nsquared.dashboard.api;

namespace SimpleComponent;

public class SimpleComponent : IComponent
{
    public string AssemblyFile => "SimpleComponent.Component";
    public string TypeName => "SimpleComponent.SimpleComponentControl";
    public string Name { get; } = "Simple Component";
    public ComponentMargin Margin { get; set; }
    public ComponentSize Size { get; set; }
    public ComponentVerticalAlignment VerticalAlignment { get; set; }
    public ComponentHorizontalAlignment HorizontalAlignment { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }

    public SimpleComponent()
    {
        VerticalAlignment = ComponentVerticalAlignment.Center;
        HorizontalAlignment = ComponentHorizontalAlignment.Right;
        Margin = new ComponentMargin
        {
            Top = 40,
            Left = 40,
            Bottom = 40,
            Right = 40
        };
        Size = new ComponentSize
        {
            Width = 320,
            Height = 160
        };
    }
}
```

The important values are:

- `AssemblyFile` — the compiled component assembly, such as `SimpleComponent.Component`
- `TypeName` — the Avalonia control type that the dashboard creates
- `Margin` — spacing around the component
- `Size` — the requested width and height
- `VerticalAlignment` and `HorizontalAlignment` — where the component sits inside the layout

## Keep the layout and component aligned

When hosting a component in a layout, the component metadata must match the actual Avalonia control. If the `AssemblyFile` or `TypeName` does not match the compiled class, the dashboard will not be able to create the control.

A good pattern is to:

1. Build the component project first
2. Add the component to the layout's `Load()` method
3. Rebuild the layout project
4. Load the layout in the dashboard and confirm the component appears where expected

## Build and test

From a terminal, build the layout project:

```sh
dotnet build
```

Then load the resulting layout in the nsquared dashboard application and verify that the `SimpleComponent` appears in the layout alongside the background.

---

_Next steps: Use the sample layout as your starting point and add more components by repeating the same pattern: build the component, set the metadata, and call `Components.Add(...)` from the layout's `Load()` method._
