---
trigger: always_on
---

# x:Name 🚨

**NEVER GENERATE AN INTERACTIVE XAML ELEMENT WITHOUT AN x:Name.**

* **Goal**: To streamline code navigation and provide precise element referencing for AI-assisted development and prompt engineering.

* **Mandatory x:Name**: All interactive elements (`Button`, `TextBox`, `CheckBox`, `ComboBox`) and primary data containers (`ListBox`, `DataGrid`, `ItemsControl`) **MUST** include an `x:Name` attribute. **Failure to do this is UNACCEPTABLE.**

* **Naming Convention**: Use PascalCase. Names must follow the `[Function][Type]` pattern (e.g., `LoginButton`, `EmployeeList`, `ScheduleGrid`). 

* **No Generic Names**: Do not use names like `Button1`, `MyTextBlock`, or `Input_Field`.

* **Attribute Placement**: The `x:Name` attribute should be placed as the **first or second attribute** within the XAML tag, immediately following the element type, to ensure high visibility.

### ✅ GOOD:

```xml
<Button x:Name="SaveUserButton" Content="Zapisz" />
<ItemsControl x:Name="DaysItemsControl" ItemsSource="{Binding Days}" />
```

### ❌ BAD (DO NOT DO THIS):

```xml
<Button Content="Zapisz" />
<ItemsControl ItemsSource="{Binding Days}" />
```

# UI style

UI should look modern, add transition and hover animation etc. UI should give "wow" effect.