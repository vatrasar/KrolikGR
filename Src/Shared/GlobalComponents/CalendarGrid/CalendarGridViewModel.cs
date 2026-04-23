using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Core.Models.Calendar;

namespace KrolikGR.Src.Shared.GlobalComponents.CalendarGrid;

public partial class CalendarGridViewModel : ViewModelBase
{
    [Reactive]
    private DateTime _currentMonth;

    [Reactive]
    private IReadOnlyList<CalendarDay> _days = Array.Empty<CalendarDay>();

    [Reactive]
    private CalendarDay? _selectedDay;

    [ObservableAsProperty]
    private string? _monthNameYear;

    public ReactiveCommand<CalendarDay, Unit> SelectDayCommand { get; }
    public ReactiveCommand<Unit, Unit> PreviousMonthCommand { get; }
    public ReactiveCommand<Unit, Unit> NextMonthCommand { get; }

    public CalendarGridViewModel()
    {
        _currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        _monthNameYearHelper = this.WhenAnyValue(x => x.CurrentMonth)
            .Select(date => date.ToString("MMMM yyyy"))
            .ToProperty(this, x => x.MonthNameYear);

        this.WhenAnyValue(x => x.CurrentMonth)
            .Subscribe(_ => GenerateDays());

        SelectDayCommand = ReactiveCommand.Create<CalendarDay>(day =>
        {
            SelectedDay = day;
        });

        PreviousMonthCommand = ReactiveCommand.Create(() =>
        {
            CurrentMonth = CurrentMonth.AddMonths(-1);
        });

        NextMonthCommand = ReactiveCommand.Create(() =>
        {
            CurrentMonth = CurrentMonth.AddMonths(1);
        });
    }

    private void GenerateDays()
    {
        var days = new List<CalendarDay>();
        var firstDayOfMonth = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1);
        
        int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
        int daysBeforeMonthStarts = firstDayOfWeek == 0 ? 6 : firstDayOfWeek - 1;

        var startDate = firstDayOfMonth.AddDays(-daysBeforeMonthStarts);
        
        var random = new Random(CurrentMonth.Month); 
        const int totalDaysInGrid = 42;

        for (int i = 0; i < totalDaysInGrid; i++)
        {
            var date = startDate.AddDays(i);
            var isCurrentMonth = date.Month == CurrentMonth.Month;
            
            days.Add(new CalendarDay
            {
                Date = date,
                IsCurrentMonth = isCurrentMonth,
                FillPercentage = isCurrentMonth ? random.Next(20, 100) : 0,
                CrewPercentage = isCurrentMonth ? random.Next(40, 100) : 0,
                ManagersPercentage = isCurrentMonth ? random.Next(50, 100) : 0,
                MaintenancePercentage = isCurrentMonth ? random.Next(30, 100) : 0
            });
        }

        Days = days;
    }
}
