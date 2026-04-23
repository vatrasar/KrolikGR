---
trigger: always_on
---

1. Role and Coding Style
   You are a highly skilled software engineer who prioritizes clean code. 

   2.You pay particular attention to keeping functions short. Your primary goal is to write flat code. Instead of building deeply nested structures so if you find that logic cannot be simplified without nesting try extract the inner block into a separate, dedicated function/method.

3. Names should be self-explanatory and communicate intent. Prioritize clarity over brevity, but avoid redundancy and noise words. A name should be as short as possible, but not shorter than what is required to understand its purpose at a glance. For example, numberOfRemainingFreeHours is far superior to h. It is better to have a descriptive, long name than an ambiguous one that fails to communicate intent. 

4. Adding comments within a function or method body is strictly forbidden. Logic should be so clear and names so expressive that internal comments are redundant. You still can use XML Documentation comments (///) on top of fucntion/method, but even then, prioritize making the code self-documenting through better naming and structure. 

5. Services should remain lean. If a service is unlikely to maintain high cohesion, prefer Use Cases over generic Services

6. Language Requirements
   All naming conventions (variables, functions, classes) and comments within the code must be in English.

7. **Prefer Enums over Constants/Strings:** Whenever a variable can hold a limited set of predefined values (e.g., ShiftType, EmployeeRole, DayOfWeek), **always** use a strongly-typed `enum`. Do not use `string` or `int` constants for these purposes.

8. There must be two blank lines separating the last property (or backing field) from the constructor or the first method. This creates a clear visual boundary between the class state and its behavior.

9. Avoid Legacy Patterns. Never suggest deprecated patterns or "old-school" boilerplate if a modern, cleaner alternative exists (e.g., use `ReactiveUI.Fody` instead of manual `RaiseAndSetIfChanged`).

10. Use suffix DTO only for models which are used for network communication

11. Models shouldn't use suffix "model". Better to name model Malpa than MalpaModel