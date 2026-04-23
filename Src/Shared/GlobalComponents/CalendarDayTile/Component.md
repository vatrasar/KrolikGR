# CalendarDayTile

## Purpose
This component represents a single day tile within a calendar grid. It provides a visual representation of a specific date and its staffing status.

## Usage
The component is a **Dumb Component (Stateless)** and binds directly to a `CalendarDay` model.

### Properties / Bindings
- `DataContext`: Must be an instance of `KrolikGR.Src.Core.Models.Calendar.CalendarDay`.
- `Date.Day`: Displays the day of the month.
- `FillPercentage`: Binds to a progress bar indicating overall staffing fill.
- `IsCurrentMonth`: Used to dim tiles that belong to adjacent months.

## Key UI Elements
- `DateText` (TextBlock): Displays the numeric day of the month.
- `FillProgressBar` (ProgressBar): Shows the percentage of staffing completed for that day.

## Used In
- [CalendarGridView](file:///home/vatrasar/projekty/KrolikGR/Src/Shared/GlobalComponents/CalendarGrid/CalendarGridView.axaml)
