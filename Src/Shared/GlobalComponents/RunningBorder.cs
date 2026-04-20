using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace KrolikGR.Src.Shared.GlobalComponents;

public class RunningBorder : Border
{
    public static readonly StyledProperty<Color> RunningColorProperty =
        AvaloniaProperty.Register<RunningBorder, Color>(nameof(RunningColor), Color.Parse("#2ECC71"));

    public static readonly StyledProperty<Color> BaseBorderColorProperty =
        AvaloniaProperty.Register<RunningBorder, Color>(nameof(BaseBorderColor), Colors.Gray);

    public static readonly StyledProperty<double> AnimationDurationProperty =
        AvaloniaProperty.Register<RunningBorder, double>(nameof(AnimationDuration), 3.0);

    public Color RunningColor
    {
        get => GetValue(RunningColorProperty);
        set => SetValue(RunningColorProperty, value);
    }

    public Color BaseBorderColor
    {
        get => GetValue(BaseBorderColorProperty);
        set => SetValue(BaseBorderColorProperty, value);
    }

    public double AnimationDuration
    {
        get => GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }


    private ConicGradientBrush? _gradientBrush;
    private DispatcherTimer? _animationTimer;
    private double _currentAngle;
    private bool _isAttachedToVisualTree;

    static RunningBorder()
    {
        RunningColorProperty.Changed.AddClassHandler<RunningBorder>((border, _) => border.RebuildGradientStops());
        BaseBorderColorProperty.Changed.AddClassHandler<RunningBorder>((border, _) => border.RebuildGradientStops());
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        _isAttachedToVisualTree = true;

        _gradientBrush = BuildGradientBrush();
        BorderBrush = _gradientBrush;

        UpdateAnimationState();
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        _isAttachedToVisualTree = false;
        StopAnimation();
        base.OnDetachedFromVisualTree(e);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (change.Property == IsVisibleProperty)
        {
            UpdateAnimationState();
        }
    }

    private void UpdateAnimationState()
    {
        if (IsVisible && _isAttachedToVisualTree)
            StartAnimation();
        else
            StopAnimation();
    }

    private void StartAnimation()
    {
        if (_animationTimer != null) return;

        _animationTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(16)
        };
        _animationTimer.Tick += OnAnimationTick;
        _animationTimer.Start();
    }

    private void StopAnimation()
    {
        if (_animationTimer == null) return;

        _animationTimer.Stop();
        _animationTimer.Tick -= OnAnimationTick;
        _animationTimer = null;
    }

    private void OnAnimationTick(object? sender, EventArgs e)
    {
        var degreesPerTick = 360.0 / (AnimationDuration * 60.0);
        _currentAngle = (_currentAngle + degreesPerTick) % 360;

        if (_gradientBrush != null)
            _gradientBrush.Angle = _currentAngle;
    }

    private void RebuildGradientStops()
    {
        if (_gradientBrush == null) return;
        _gradientBrush.GradientStops = BuildGradientStops();
    }

    private ConicGradientBrush BuildGradientBrush()
    {
        return new ConicGradientBrush
        {
            Center = new RelativePoint(0.5, 0.5, RelativeUnit.Relative),
            Angle = _currentAngle,
            GradientStops = BuildGradientStops()
        };
    }

    private GradientStops BuildGradientStops()
    {
        return new GradientStops
        {
            new GradientStop(BaseBorderColor, 0.0),
            new GradientStop(BaseBorderColor, 0.85),
            new GradientStop(RunningColor, 0.90),
            new GradientStop(RunningColor, 0.95),
            new GradientStop(BaseBorderColor, 1.0),
        };
    }
}
