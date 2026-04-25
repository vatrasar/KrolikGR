using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Core.Models.Calendar;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar.ScreenComponents.DaySummaryPanel;

public partial class DaySummaryPanelViewModel : ViewModelBase
{
    [Reactive]
    private CalendarDay? _selectedDay;

    [ReactiveCommand]
    private void ClosePanel()
    {
        // The actual logic is handled by the parent observing this command
    }

    [ReactiveCommand]
    private void AddCrew()
    {
        // Placeholder for add crew logic
    }

    [ReactiveCommand]
    private void ShowDayDetails()
    {
        // Placeholder for show day details logic
    }
}
