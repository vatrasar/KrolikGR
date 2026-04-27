using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive.Disposables;
using KrolikGR.Src.Features.Schedule.UI.Screens.DayDetails;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.DayDetails.ScreenComponents;

public partial class DayDetailsRowView : ReactiveUserControl<HourRow>
{
    public DayDetailsRowView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.Hour, v => v.HourText.Text)
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, vm => vm.StaffValue, v => v.StaffText.Text)
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, vm => vm.ServiceHead, v => v.ServiceHeadText.Text)
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, vm => vm.ShiftManager, v => v.ShiftManagerText.Text)
                .DisposeWith(disposables);
            
            this.OneWayBind(ViewModel, vm => vm.CleanerCount, v => v.CleanerText.Text,
                count => count > 0 ? count.ToString() : string.Empty)
                .DisposeWith(disposables);
        });
    }
}
