using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.ScheduleCalendar;

public partial class ScheduleCalendarView : ReactiveUserControl<ScheduleCalendarViewModel>
{
    public ScheduleCalendarView()
    {
        InitializeComponent();
        this.WhenActivated(disposables => 
        { 
        });
    }
}
