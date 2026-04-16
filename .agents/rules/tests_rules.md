---
trigger: model_decision
description: Use it when you create unit tests
---

Tests

## 

# Avalonia.Headless

The project is equipped with Avalonia.Headless.XUnit and Avalonia.Themes.Fluent. You are encouraged to use these for UI-integrated testing and functional verification. For standard unit testing, the project utilizes xUnit and Moq for mocking dependencies.

Note: A TestAppBuilder has been pre-configured for this library to facilitate headless Avalonia application bootstrapping within the test suite.

# Test functions name

when you make testing function you should name them in following way

```csharp
NameOfTestedFuntion_testCondition_expectedResult
```

for example for function GetTimeSlotsList you can have name of testing function like that

```cs
GetTimeSlotsList_ForDataWhichArenTSorted_ReturnsSortedTimeSlotList
```