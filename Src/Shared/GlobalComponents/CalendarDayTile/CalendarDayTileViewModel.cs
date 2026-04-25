using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Core.Models.Calendar;

namespace KrolikGR.Src.Shared.GlobalComponents.CalendarDayTile;

public partial class CalendarDayTileViewModel : ViewModelBase
{
    [Reactive]
    private CalendarDay _day;

    public CalendarDayTileViewModel(CalendarDay day)
    {
        _day = day;
    }

    [ReactiveCommand]
    private CalendarDay SelectDay()
    {
        return Day;
    }
}
