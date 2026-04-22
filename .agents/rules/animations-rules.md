---
trigger: model_decision
description: Use it when you create or edit animations
---

# UI Animations and Timers

Using `DispatcherTimer` for creating high-frequency UI animations (e.g., rotating brushes, moving elements at 60 FPS) is strictly forbidden. This approach is legacy, inefficient, and not synchronized with the screen refresh rate (VSync).

- **Animations:** Use Avalonia's built-in `Animation` class with `KeyFrames` or `Transitions` for property-based animations.
- **Continuous Updates:** If you must perform custom rendering updates from code-behind, use `CompositionTarget.Rendering` or `TopLevel.RequestAnimationFrame` to ensure the logic ticks in sync with the display's VSync.



# UI Component Cleanup
 In Avalonia controls, ensure all background tasks are cancelled in `OnDetachedFromVisualTree`. If a task is tied to visibility, manage it in `OnPropertyChanged` when `IsVisible` changes.



# VisualBrush and animations
When working with Avalonia UI animations and brushes, remember that XAML `<Animation>` definitions DO NOT tick or update continuously if they are placed on elements inside a `VisualBrush` (or `DrawingBrush`). Elements inside a `Visual` property of a `VisualBrush` are not fully connected to the main window's visual tree's render clock. If you need an animated brush (like a rotating gradient or moving element), do NOT put the XAML `<Animation>` inside a `VisualBrush.Visual`. 