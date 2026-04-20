using KrolikGR.Src.Core.Infrastructure;
using KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar;
using ReactiveUI;
using Splat;

namespace KrolikGR.Src.Features.Schedule;

public class ScheduleModule : IFeatureModule
{
    public void Register(IMutableDependencyResolver services)
    {
        services.Register(() => new ScheduleCalendarView(), typeof(IViewFor<ScheduleCalendarViewModel>));
    }
}
