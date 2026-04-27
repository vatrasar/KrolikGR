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
    }

    [ReactiveCommand]
    private void AddCrew()
    {
    }

    [ReactiveCommand]
    private void ShowDayDetails()
    {
    }
}
