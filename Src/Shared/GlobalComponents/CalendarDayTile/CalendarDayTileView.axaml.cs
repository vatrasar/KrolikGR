using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive.Disposables;
using System;

namespace KrolikGR.Src.Shared.GlobalComponents.CalendarDayTile;

/// <summary>
/// # CalendarDayTile
/// 
/// ## Purpose
/// This component represents a single day tile within a calendar grid. It provides a visual representation of a specific date and its staffing status.
/// 
/// ## Usage
/// The component is a **Smart Component**. It binds to its ViewModel properties in the code-behind.
/// 
/// ### Properties / Bindings
/// - `ViewModel.Day`: The `CalendarDay` model data.
/// - `ViewModel.SelectDayCommand`: Command triggered when the tile is clicked.
/// 
/// ## Key UI Elements
/// - `DateText` (TextBlock): Displays the numeric day of the month.
/// - `FillProgressBar` (ProgressBar): Visualizes the staffing fill percentage.
/// - `SelectDayButton` (Button): Wraps the tile and triggers the selection command.
/// 
/// ## Used In
/// - [CalendarGridView](file:///home/vatrasar/projekty/KrolikGR/Src/Shared/GlobalComponents/CalendarGrid/CalendarGridView.axaml)
/// </summary>
public partial class CalendarDayTileView : ReactiveUserControl<CalendarDayTileViewModel>
{
    public CalendarDayTileView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.Day.Date.Day, v => v.DateText.Text, 
                day => day.ToString())
                .DisposeWith(disposables);

            this.OneWayBind(ViewModel, vm => vm.Day.FillPercentage, v => v.FillProgressBar.Value)
                .DisposeWith(disposables);

            this.WhenAnyValue(x => x.ViewModel!.Day.IsCurrentMonth)
                .Subscribe(isCurrent => TileBorder!.Classes.Set("not-current-month", !isCurrent))
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.SelectDayCommand, v => v.SelectDayButton)
                .DisposeWith(disposables);
        });
    }
}
