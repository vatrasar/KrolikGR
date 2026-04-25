using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Windows.Input;
using KrolikGR.Src.Core.Models.Calendar;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar.ScreenComponents.DaySummaryPanel;

/// <summary>
/// # DaySummaryPanel
/// 
/// ## Purpose
/// Displays detailed staffing information for a selected day. It acts as a side panel or detail view within the schedule calendar screen.
/// 
/// ## Usage
/// This is a **Dumb Component (Stateless)**. Data and commands are injected via `StyledProperty` bindings.
/// 
/// ### Properties / Bindings
/// - `SelectedDay` (`CalendarDay?`): The day data to display. Set from the parent's ViewModel.
/// - `CloseCommand` (`ICommand?`): Command to collapse/hide the summary panel. Set from the parent's ViewModel.
/// 
/// ## Key UI Elements
/// - `CloseButton` (Button): Triggers `CloseCommand` to collapse the panel.
/// - `AddCrewButton` (Button): Action to add crew members to the schedule.
/// - `ShowDayDetailsButton` (Button): Navigates to a more detailed view of the day's schedule.
/// - Staffing ProgressBars: Visual representation of coverage for different roles.
/// 
/// ## Used In
/// - [ScheduleCalendarView](file:///home/vatrasar/projekty/KrolikGR/Src/Features/Schedule/UI/Screens/ScheduleCalendar/ScheduleCalendarView.axaml)
/// </summary>
public partial class DaySummaryPanelView : UserControl
{
    public static readonly StyledProperty<CalendarDay?> SelectedDayProperty =
        AvaloniaProperty.Register<DaySummaryPanelView, CalendarDay?>(nameof(SelectedDay));

    public static readonly StyledProperty<ICommand?> CloseCommandProperty =
        AvaloniaProperty.Register<DaySummaryPanelView, ICommand?>(nameof(CloseCommand));


    public CalendarDay? SelectedDay
    {
        get => GetValue(SelectedDayProperty);
        set => SetValue(SelectedDayProperty, value);
    }

    public ICommand? CloseCommand
    {
        get => GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }


    public DaySummaryPanelView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
