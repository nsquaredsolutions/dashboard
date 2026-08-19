# Building a Component for nsquared dashboard

This guide will walk you through the process of creating your own component for the nsquared dashboard. A component is a reusable UI element that can be placed inside a layout. It has a visual definition, sizing and alignment metadata, and a small set of parameters that the dashboard can use when it is hosted in a layout.

## Outline

### 1. Prerequisites

- Basic knowledge of C# and XAML (Avalonia UI)
- .NET 10 SDK installed
- A layout project or sample layout to host the component

### 2. Project Setup

- Create a new folder for your component
- Add a new Class Library project (for example, `SimpleComponent`)
- Reference `nsquared.dashboard.api` NuGet package in your project
- Add Avalonia NuGet package

1. Start by creating a new C# class library project named `SimpleComponent`.

   ```bash
   dotnet new classlib --name SimpleComponent
   ```

   This creates a new folder named `SimpleComponent` with a C# project and a default file named `Class1.cs`.

2. Rename the file `Class1.cs` to `Component.cs`.
3. Rename the class in the code to `ClockComponent`.

   ```cs
   namespace SimpleComponent;

   public class ClockComponent
   {
   }
   ```

4. In the `SimpleComponent.csproj` file, make sure the `TargetFramework` is `net10.0`.

   ```xml
   <TargetFramework>net10.0</TargetFramework>
   ```

5. In the `SimpleComponent.csproj` file, add a `TargetExt` field below the `TargetFramework` line.

   ```xml
   <TargetExt>.Component</TargetExt>
   ```

6. Add a package reference to the `nsquared.dashboard.api` NuGet package.

   ```sh
   dotnet add package nsquared.dashboard.api
   ```

7. Add a package reference to the `Avalonia` NuGet package.

   ```sh
   dotnet add package Avalonia
   ```

8. In the `Component.cs` file, add the `nsquared.dashboard.api` namespace.

   ```cs
   using nsquared.dashboard.api;
   ```

9. Implement the `IComponent` interface in the `ClockComponent` class.

   ```cs
   public class ClockComponent : IComponent
   {
   }
   ```

10. Add the required properties to the class.

   ```cs
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
   ```

A layout contains a list of components and decides where they are placed. A component itself is just a reusable visual element with metadata describing how the dashboard should render it. The key values are `AssemblyFile`, `TypeName`, `Margin`, `Size`, `VerticalAlignment`, `HorizontalAlignment`, and `Parameters`.

### 3. Create the Visual Control

A component is usually backed by an Avalonia `UserControl`. Create a new file named `ClockComponentControl.axaml` in the project folder.

```xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d" d:DesignWidth="320" d:DesignHeight="160"
             x:Class="SimpleComponent.ClockComponentControl">
    <Border Background="#121826" CornerRadius="18" Padding="20">
        <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center">
            <TextBlock Text="Current Time" Foreground="White" FontSize="18" FontWeight="SemiBold"/>
            <TextBlock Text="10:25 AM" Foreground="#87FF9D" FontSize="40" FontWeight="Bold"/>
        </StackPanel>
    </Border>
</UserControl>
```

Create the corresponding code-behind file named `ClockComponentControl.axaml.cs`.

```cs
using Avalonia.Controls;

namespace SimpleComponent;

public partial class ClockComponentControl : UserControl
{
     public ClockComponentControl():this([])
    {
        
    }
    public ClockComponentControl(Dictionary<string, string> parameters)
    {
        InitializeComponent();
    }
}
```

### 4. Project Structure

Your project structure should look like this:

- Main component XAML file (for example, `ClockComponentControl.axaml`)
- Main component code-behind (for example, `ClockComponentControl.axaml.cs`)
- Component implementation class (for example, `ClockComponent.cs`)
- Project file (`.csproj`)

### 5. Building and Testing

- Build your project to generate the `SimpleComponent.Component` assembly
- Install or load the component in the nsquared dashboard application using the licensed component flow
- Test the component inside a layout

Build the component project using the following command:

```sh
dotnet build
```

This will compile the project and generate a `.Component` file in the output directory.

Once the `.Component` file is built, add it to the dashboard using the same component installation flow used for other custom components. 

Then add that component to a layout and verify the visual result.

[Information on hosting a component in a layout](/Docs/Layouts/Hosting%20a%20Component%20in%20a%20Layout)

### 6. Tips and Best Practices

- Keep components small and focused on one task or visual purpose
- Reuse the `SimpleLayout` sample as a reference for how layouts load and host components
- Use correct `AssemblyFile` and `TypeName` values so the dashboard can find the Avalonia control
- Use meaningful names and consistent margins, sizes, and alignment values

---

[For more information on building a layout](/Docs/Layouts/Building%20a%20Layout)

[Information on hosting a component in a layout](/Docs/Layouts/Hosting%20a%20Component%20in%20a%20Layout)