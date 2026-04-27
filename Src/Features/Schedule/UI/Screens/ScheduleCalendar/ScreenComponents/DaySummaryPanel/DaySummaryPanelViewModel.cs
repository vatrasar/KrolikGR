using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Core.Models.Calendar;
using KrolikGR.Src.Features.Schedule.UI.Screens.DayDetails;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar.ScreenComponents.DaySummaryPanel;

public partial class DaySummaryPanelViewModel : ViewModelBase
{
    public IScreen HostScreen { get; }

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
        HostScreen.Router.Navigate.Execute(new DayDetailsViewModel(HostScreen, SelectedDay));
    }

    public DaySummaryPanelViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
}
