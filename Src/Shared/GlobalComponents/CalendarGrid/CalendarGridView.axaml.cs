using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KrolikGR.Src.Shared.GlobalComponents.CalendarGrid;

public partial class CalendarGridView : UserControl
{
    public CalendarGridView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
