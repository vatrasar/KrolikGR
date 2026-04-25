using ReactiveUI;
using ReactiveUI.SourceGenerators;
using System;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Shared.GlobalComponents.CalendarGrid;
using KrolikGR.Src.Core.Models.Calendar;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar;

public partial class ScheduleCalendarViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "schedule-calendar";
    public IScreen HostScreen { get; }

    public CalendarGridViewModel CalendarGrid { get; }

    [Reactive]
    private CalendarDay? _selectedDay;

    public ScheduleCalendarViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
        CalendarGrid = new CalendarGridViewModel();

        // Observe the selected day from the calendar grid
        this.WhenAnyValue(x => x.CalendarGrid.SelectedDay)
            .Subscribe(day => SelectedDay = day);
    }

    [ReactiveCommand]
    private void CloseSummary()
    {
        CalendarGrid.SelectedDay = null;
    }
}
