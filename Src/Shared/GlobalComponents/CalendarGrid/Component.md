# CalendarGrid

## Purpose
A smart component that provides a monthly calendar view. It handles month navigation and day selection logic.

## Usage
This is a **Smart Component** driven by `CalendarGridViewModel`.

### Commands
- `PreviousMonthCommand`: Navigates to the previous month.
- `NextMonthCommand`: Navigates to the next month.
- `SelectDayCommand`: Triggered when a day tile is clicked.

### Properties
- `CurrentMonth`: The currently displayed month and year.
- `Days`: An observable collection of `CalendarDay` objects representing the grid.
- `SelectedDay`: The currently selected day in the grid.

## Key UI Elements
- `PreviousMonthButton` (Button): Triggers `PreviousMonthCommand`.
- `NextMonthButton` (Button): Triggers `NextMonthCommand`.
- `MonthYearText` (TextBlock): Displays the current month and year (e.g., "Kwiecień 2026").
- `DaysItemsControl` (ItemsControl): Renders the grid of [CalendarDayTile](file:///home/vatrasar/projekty/KrolikGR/Src/Shared/GlobalComponents/CalendarDayTile/Component.md) components.

## Used In
- [ScheduleCalendarView](file:///home/vatrasar/projekty/KrolikGR/Src/Features/Schedule/UI/Screens/ScheduleCalendar/ScheduleCalendarView.axaml)
