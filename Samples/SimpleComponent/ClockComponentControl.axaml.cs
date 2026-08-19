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