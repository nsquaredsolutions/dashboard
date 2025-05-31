# Building a Layout for nsquared Dashboard

This guide will walk you through the process of creating your own layout for the nsquared dashboard, using the `ExampleExternalLayout` project as a reference. Follow these steps to build a layout from scratch.

## Outline

### 1. Prerequisites

- Basic knowledge of C# and XAML (Avalonia UI)
- Visual Studio or compatible IDE
- .NET SDK installed

### 2. Project Setup

- Create a new folder for your layout
- Add a new Class Library project (e.g., `MyCustomLayout`)
- Reference `nsquared.dashboard.api` nuget package in your project
- Add Avalonia NuGet package 

### 3. Project Structure

- Main layout XAML file (e.g., `MainLayout.axaml`)
- Main layout code-behind (e.g., `MainLayout.axaml.cs`)
- Component(s) XAML and code-behind (e.g., `DateComponent.axaml`, `DateComponent.axaml.cs`)
- Layout implementation class (e.g., `SampleLayout.cs`)
- Component implementation class (e.g., `Component.cs`)
- Project file (`.csproj`)

### 4. Implementing the Layout

- Create a class that implements the `ILayout` interface
- Define the layout name and components list
- In the `Load()` method, instantiate and configure your components
- Add your components to the layout

### 5. Creating Components

- Create classes that implement the `IComponent` interface
- Define properties such as `AssemblyFile`, `TypeName`, `Margin`, `Size`, `Alignment`, and `Parameters`
- Implement the component's UI in XAML and code-behind

### 6. Wiring Up XAML and Code

- Design your layout and components visually in XAML
- Bind properties and handle logic in the code-behind
- Use data binding for dynamic content (e.g., dates, lists)

### 7. Building and Testing

- Build your project to generate the DLL
- Add your layout to the dashboard's configuration or settings
- Test your layout in the nsquared dashboard application

### 8. Tips and Best Practices

- Use the ExampleExternalLayout as a reference for structure and code style
- Keep components modular and reusable
- Document your code for maintainability

---

_Next steps: Follow each section in detail to implement your own layout. Refer to ExampleExternalLayout for working code samples._
