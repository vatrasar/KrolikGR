using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive.Disposables;
using System;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.DayDetails;

/// <summary>
/// # DayDetailsView
/// 
/// ## Purpose
/// This screen displays a detailed hourly breakdown of the schedule for a selected day.
/// It shows a table with 24 rows, starting from 06:00 and ending at 05:00 the next day.
/// 
/// ## Usage
/// This is a **Screen**. It is registered in ScheduleModule and navigated to via ReactiveUI Router.
/// 
/// ### Properties / Bindings
/// - `ViewModel.SelectedDay` (CalendarDay?): The day being displayed.
/// - `ViewModel.Rows` (List&lt;HourRow&gt;): Data for the 24-hour table.
/// - `ViewModel.GoBackCommand`: Command to return to the previous screen.
/// 
/// ## Key UI Elements
/// - `BackButton` (Button): Triggers `GoBackCommand`.
/// - `DateTitle` (TextBlock): Displays the selected date.
/// - `RoleSelector` (ComboBox): Allows selecting a specific role to highlight or filter (Manager, Instruktor, Lider Gościnności).
/// - `HoursItemsControl` (ItemsControl): Displays the 24-hour schedule table.
/// 
/// ## Called From
/// - [ScheduleCalendarView](file:///home/vatrasar/projekty/KrolikGR/Src/Features/Schedule/UI/Screens/ScheduleCalendar/ScheduleCalendarView.axaml) (triggered via DaySummaryPanel)
/// </summary>
public partial class DayDetailsView : ReactiveUserControl<DayDetailsViewModel>
{
    public DayDetailsView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.SelectedDay, v => v.DateTitle.Text,
                day => day?.Date.ToString("dd MMMM yyyy") ?? "Szczegóły dnia")
                .DisposeWith(disposables);

            this.OneWayBind(ViewModel, vm => vm.Rows, v => v.HoursItemsControl.ItemsSource)
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.GoBackCommand, v => v.BackButton)
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.AddCrewCommand, v => v.AddCrewButton)
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.AddManagerCommand, v => v.AddManagerButton)
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.ShowShiftCrewCommand, v => v.ShowShiftCrewButton)
                .DisposeWith(disposables);

            this.Bind(ViewModel, vm => vm.SelectedRole, v => v.RoleSelector.SelectedIndex,
                role => (int)role,
                index => (RoleType)index)
                .DisposeWith(disposables);

            this.WhenAnyValue(x => x.BackButton.Foreground)
                .Subscribe(brush => BackPath.Stroke = brush)
                .DisposeWith(disposables);
        });
    }
}
