---
trigger: model_decision
description: Use it when you create or modify Avalonia UI animations, brushes (especially VisualBrush or DrawingBrush).
---

When working with Avalonia UI animations and brushes, remember that XAML `<Animation>` definitions DO NOT tick or update continuously if they are placed on elements inside a `VisualBrush` (or `DrawingBrush`). Elements inside a `Visual` property of a `VisualBrush` are not fully connected to the main window's visual tree's render clock. If you need an animated brush (like a rotating gradient or moving element), do NOT put the XAML `<Animation>` inside a `VisualBrush.Visual`. Instead, either animate the `Brush` properties directly on the parent control, or implement the animation programmatically using a `DispatcherTimer` or Composition API in code-behind.