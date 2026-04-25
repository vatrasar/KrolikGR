using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using KrolikGR.Src.Core.Models.Calendar;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar.ScreenComponents.DaySummaryPanel;

/// <summary>
/// # DaySummaryPanel
/// 
/// ## Purpose
/// Displays detailed staffing information for a selected day. It acts as a side panel or detail view within the schedule calendar screen.
/// 
/// ## Usage
/// This is a **Smart Component**. It uses its own ViewModel and binds to its properties in the code-behind.
/// 
/// ### Properties / Bindings
/// - `ViewModel.SelectedDay` (`CalendarDay?`): The day data to display.
/// - `ViewModel.ClosePanelCommand`: Command to collapse/hide the summary panel.
/// 
/// ## Key UI Elements
/// - `CloseButton` (Button): Triggers `ClosePanelCommand`.
/// - `AddCrewButton` (Button): Action to add crew members to the schedule.
/// - `ShowDayDetailsButton` (Button): Navigates to a more detailed view of the day's schedule.
/// - Staffing ProgressBars: Visual representation of coverage for different roles.
/// 
/// ## Used In
/// - [ScheduleCalendarView](file:///home/vatrasar/projekty/KrolikGR/Src/Features/Schedule/UI/Screens/ScheduleCalendar/ScheduleCalendarView.axaml)
/// </summary>
public partial class DaySummaryPanelView : ReactiveUserControl<DaySummaryPanelViewModel>
{
    public DaySummaryPanelView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            // Bind Selected Day properties using type-safe OneWayBind
            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.DateText.Text, 
                day => day?.Date.ToString("dd MMMM yyyy"))
                .DisposeWith(disposables);

            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.CrewProgressBar.Value,
                day => (double)(day?.CrewPercentage ?? 0))
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.CrewPercentageText.Text,
                day => day != null ? $"{day.CrewPercentage}%" : string.Empty)
                .DisposeWith(disposables);

            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.ManagersProgressBar.Value,
                day => (double)(day?.ManagersPercentage ?? 0))
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.ManagersPercentageText.Text,
                day => day != null ? $"{day.ManagersPercentage}%" : string.Empty)
                .DisposeWith(disposables);

            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.MaintenanceProgressBar.Value,
                day => (double)(day?.MaintenancePercentage ?? 0))
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.MaintenancePercentageText.Text,
                day => day != null ? $"{day.MaintenancePercentage}%" : string.Empty)
                .DisposeWith(disposables);

            // Bind Commands
            this.BindCommand(ViewModel, vm => vm.ClosePanelCommand, v => v.CloseButton)
                .DisposeWith(disposables);
            
            this.BindCommand(ViewModel, vm => vm.AddCrewCommand, v => v.AddCrewButton)
                .DisposeWith(disposables);
            
            this.BindCommand(ViewModel, vm => vm.ShowDayDetailsCommand, v => v.ShowDayDetailsButton)
                .DisposeWith(disposables);

            // Bind Path Stroke to Button Foreground
            this.WhenAnyValue(x => x.CloseButton.Foreground)
                .Subscribe(brush => ClosePath.Stroke = brush)
                .DisposeWith(disposables);
        });
    }

}
