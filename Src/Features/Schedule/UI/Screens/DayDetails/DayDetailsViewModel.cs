using ReactiveUI;
using ReactiveUI.SourceGenerators;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Core.Models.Calendar;
using System.Reactive;
using System.Reactive.Linq;
using System.Collections.Generic;

namespace KrolikGR.Src.Features.Schedule.UI.Screens.DayDetails;

public partial class DayDetailsViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment => "day-details";
    public IScreen HostScreen { get; }

    [Reactive]
    private CalendarDay? _selectedDay;

    [ObservableAsProperty]
    private string? _staffSummary;

    [Reactive]
    private RoleType _selectedRole = RoleType.Sprzątacz;

    public List<HourRow> Rows { get; } = new();

    [ReactiveCommand]
    private void GoBack()
    {
        HostScreen.Router.NavigateBack.Execute(Unit.Default);
    }

    public DayDetailsViewModel(IScreen hostScreen, CalendarDay? selectedDay = null)
    {
        HostScreen = hostScreen;
        SelectedDay = selectedDay;
        
        _staffSummaryHelper = this.WhenAnyValue(x => x.SelectedDay)
            .Select(day => day != null ? $"Obsada: {day.StaffCount} / {day.RequiredStaffCount}" : "Obsada: 0 / 0")
            .ToProperty(this, x => x.StaffSummary);


        for (int i = 0; i < 26; i++)
        {
            int hour = (5 + i) % 24;
            int nextHour = (hour + 1) % 24;
            var row = new HourRow { Hour = $"{hour}-{nextHour}" };
            
            if (i < 8)
            {
                row.StaffValue = "4/6";
                row.ServiceHead = "Jan Kowalski";
                row.ShiftManager = "Anna Nowak";
                row.CleanerCount = 2;
            }
            else
            {
                row.StaffValue = "2/4";
            }
            
            Rows.Add(row);
        }
    }
}

public class HourRow
{
    public string Hour { get; set; } = string.Empty;
    public string StaffValue { get; set; } = "0/0";
    public string ServiceHead { get; set; } = string.Empty;
    public string ShiftManager { get; set; } = string.Empty;
    public int CleanerCount { get; set; }
}

public enum RoleType
{
    Sprzątacz,
    Manager,
    Instruktor,
    LiderGościnności
}
