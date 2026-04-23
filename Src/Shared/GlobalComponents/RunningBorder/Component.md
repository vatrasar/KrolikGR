# RunningBorder

## Purpose
A premium custom control that extends the standard `Border` with a "running" light animation effect along its edges. It is used to draw attention to specific UI elements or provide a high-end feel to the application.

## Usage
The component is a custom control implemented in C#. It can be used in XAML like a regular `Border`.

### Properties
- `RunningColor` (Color): The color of the moving light highlight.
- `BaseBorderColor` (Color): The base color of the border when the highlight is not over it.
- `AnimationDuration` (double): The time in seconds for the light to complete one full loop around the border.

### Example
```xml
<components:RunningBorder BaseBorderColor="Transparent" 
                          RunningColor="Gold" 
                          AnimationDuration="5" 
                          BorderThickness="2" 
                          CornerRadius="4">
    <!-- Content goes here -->
</components:RunningBorder>
```

## Key UI Elements
- `ConicGradientBrush`: Used to create the highlight effect that rotates around the center of the border.

## Used In
- [HostView](file:///home/vatrasar/projekty/KrolikGR/Src/Features/Shell/UI/Screens/Host/HostView.axaml)
