using System;
using System.Threading;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;

namespace KrolikGR.Src.Shared.GlobalComponents.RunningBorder;

/// <summary>
/// A reusable component that represents a border with a "running" light effect.
/// It animates a ConicGradientBrush to create a highlight that moves around the border edges.
/// </summary>
public class RunningBorder : Border
{
    public static readonly StyledProperty<Color> RunningColorProperty =
        AvaloniaProperty.Register<RunningBorder, Color>(nameof(RunningColor), Colors.Transparent);

    public static readonly StyledProperty<Color> BaseBorderColorProperty =
        AvaloniaProperty.Register<RunningBorder, Color>(nameof(BaseBorderColor), Colors.Transparent);

    public static readonly StyledProperty<double> AnimationDurationProperty =
        AvaloniaProperty.Register<RunningBorder, double>(nameof(AnimationDuration), 12.0);

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
    private Animation? _animation;
    private CancellationTokenSource? _cts;
    private bool _isAttachedToVisualTree;

    static RunningBorder()
    {
        RunningColorProperty.Changed.AddClassHandler<RunningBorder>((border, _) => border.RebuildGradientStops());
        BaseBorderColorProperty.Changed.AddClassHandler<RunningBorder>((border, _) => border.RebuildGradientStops());
        AnimationDurationProperty.Changed.AddClassHandler<RunningBorder>((border, _) => border.RebuildAnimation());
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        _isAttachedToVisualTree = true;

        _gradientBrush = BuildGradientBrush();
        BorderBrush = _gradientBrush;
        
        RebuildAnimation();
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

    private void RebuildAnimation()
    {
        _animation = new Animation
        {
            Duration = TimeSpan.FromSeconds(AnimationDuration),
            IterationCount = IterationCount.Infinite,
            Easing = new LinearEasing(),
            Children =
            {
                new KeyFrame
                {
                    Cue = new Cue(0d),
                    Setters = { new Setter(ConicGradientBrush.AngleProperty, 0.0) }
                },
                new KeyFrame
                {
                    Cue = new Cue(1d),
                    Setters = { new Setter(ConicGradientBrush.AngleProperty, 360.0) }
                }
            }
        };

        if (_cts != null)
        {
            StartAnimation();
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
        StopAnimation();
        
        if (_gradientBrush != null && _animation != null)
        {
            _cts = new CancellationTokenSource();
            _ = _animation.RunAsync(_gradientBrush, _cts.Token);
        }
    }

    private void StopAnimation()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;
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
            Angle = 0.0,
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
