using ReactiveUI;
using ReactiveUI.SourceGenerators;
using KrolikGR.Src.Core.Mvvm;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar;

public partial class ScheduleCalendarViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "schedule-calendar";
    public IScreen HostScreen { get; }

    public ScheduleCalendarViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
}
