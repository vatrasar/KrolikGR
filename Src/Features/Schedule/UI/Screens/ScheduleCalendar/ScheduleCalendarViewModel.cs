using ReactiveUI;
using ReactiveUI.SourceGenerators;
using System;
using System.Reactive.Linq;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Shared.GlobalComponents.CalendarGrid;
using KrolikGR.Src.Core.Models.Calendar;
using KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar.ScreenComponents.DaySummaryPanel;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar;

public partial class ScheduleCalendarViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "schedule-calendar";
    public IScreen HostScreen { get; }

    public CalendarGridViewModel CalendarGrid { get; }
    
    public DaySummaryPanelViewModel SummaryPanel { get; }

    [Reactive]
    private CalendarDay? _selectedDay;

    public ScheduleCalendarViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
        CalendarGrid = new CalendarGridViewModel();
        SummaryPanel = new DaySummaryPanelViewModel(hostScreen);

        this.WhenAnyValue(x => x.CalendarGrid.SelectedDay)
            .Subscribe(day => 
            {
                SelectedDay = day;
                SummaryPanel.SelectedDay = day;
            });

        SummaryPanel.ClosePanelCommand
            .Subscribe(_ => 
            {
                CalendarGrid.SelectedDay = null;
            });
    }
}
