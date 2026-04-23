using System;

namespace KrolikGR.Src.Core.Models.Calendar;

public class CalendarDay
{
    public DateTime Date { get; set; }
    public double FillPercentage { get; set; }
    public bool IsCurrentMonth { get; set; }
    public double CrewPercentage { get; set; }
    public double ManagersPercentage { get; set; }
    public double MaintenancePercentage { get; set; }
}
