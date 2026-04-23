using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using KrolikGR.Src.Core.Models.Calendar;

namespace KrolikGR.Src.Shared.GlobalComponents.CalendarDayTile;

public partial class CalendarDayTileView : UserControl
{
    public CalendarDayTileView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
