using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar.ScreenComponents.DaySummaryPanel;

/// <summary>
/// # DaySummaryPanel
/// 
/// ## Purpose
/// Displays detailed staffing information for a selected day. It acts as a side panel or detail view within the schedule calendar screen.
/// 
/// ## Usage
/// This is a **Dumb Component (Stateless)** and binds directly to a `CalendarDay` model.
/// 
/// ### Properties / Bindings
/// - `DataContext`: Must be an instance of `KrolikGR.Src.Core.Models.Calendar.CalendarDay`.
/// - `Date`: Displays the full date (e.g., "23 kwietnia 2026").
/// - `CrewPercentage`, `ManagersPercentage`, `MaintenancePercentage`: Bind to progress bars for specific roles.
/// 
/// ## Key UI Elements
/// - `AddCrewButton` (Button): Action to add crew members to the schedule.
/// - `ShowDayDetailsButton` (Button): Navigates to a more detailed view of the day's schedule.
/// - Staffing ProgressBars: Visual representation of coverage for different roles.
/// 
/// ## Used In
/// - [ScheduleCalendarView](file:///home/vatrasar/projekty/KrolikGR/Src/Features/Schedule/UI/Screens/ScheduleCalendar/ScheduleCalendarView.axaml)
/// </summary>
public partial class DaySummaryPanelView : UserControl
{
    public DaySummaryPanelView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
