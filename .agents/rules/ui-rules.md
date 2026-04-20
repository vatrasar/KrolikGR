# UI Element Naming Convention (x:Name)
* Goal: To streamline code navigation and provide precise element referencing for AI-assisted development and prompt engineering.

* Mandatory x:Name: All interactive elements (Button, TextBox, CheckBox, ComboBox) and primary data containers (ListBox, DataGrid, ItemsControl) MUST include an x:Name attribute.

* Naming Convention: Use PascalCase. Names must follow the [Function][Type] pattern (e.g., LoginButton, EmployeeList, ScheduleGrid).

* No Generic Names: Do not use names like Button1, MyTextBlock, or Input_Field.

Attribute Placement: The x:Name attribute should be placed as the first or second attribute within the XAML tag, immediately following the element type, to ensure high visibility.