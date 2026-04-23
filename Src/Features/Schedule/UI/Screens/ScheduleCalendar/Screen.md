# Schedule Calendar Screen

## Purpose
The Schedule Calendar screen is the primary interface for viewing and managing the restaurant's work schedule. It provides a monthly overview of the schedule with the ability to see daily summaries and staffing percentages.

## Functionalities
- **Interactive Calendar Grid**: Displays the days of the month with summary indicators for staffing levels.
- **Day Selection**: Clicking on a day in the calendar selects it and opens the summary panel.
- **Staffing Overview**: Shows staffing percentages for different roles (Crew, Managers, Maintenance) for the selected day.
- **Dynamic Animations**: The summary panel slides in and fades in when a day is selected, and slides out when selection is cleared.

## Key UI Elements
- **CalendarGrid (Global Component)**: The main 7-column grid displaying the month's days.
- **DaySummaryPanel (Screen Component)**: A side panel that appears on the right when a day is selected.
    - **Staffing Progress Bars**: Visual representation of "Zapełnienie etatów" for Załoga, Managerowie, and Sprzątacze.
    - **Action Buttons**: Buttons for "Dodaj załogę" and "Pokaż szczegóły dnia".

## Technical Details
- **Routing**: Implements `IRoutableViewModel` with the segment `schedule-calendar`.
- **Transitions**: Uses Avalonia `Transitions` for the summary panel:
    - `DoubleTransition` for `Width` and `Opacity`.
    - `ThicknessTransition` for `Margin`.
- **Components**: 
    - Uses `CalendarGridView` (Global Component).
    - Uses `DaySummaryPanelView` (Dumb Screen Component).
