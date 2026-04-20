using ReactiveUI;
using ReactiveUI.SourceGenerators;
using Avalonia;
using Avalonia.Styling;
using Material.Icons;
using System.Reactive.Linq;
using KrolikGR.Src.Core.Mvvm;


namespace KrolikGR.Src.Features.Shell.UI.Screens.Host;

public partial class HostViewModel : ViewModelBase, IScreen
{
    [Reactive]
    private bool _isMenuCollapsed;

    public MaterialIconKind ThemeIcon => IsDarkTheme ? MaterialIconKind.WeatherSunny : MaterialIconKind.WeatherNight;

    public RoutingState Router { get; }

    public HostViewModel(RoutingState router)
    {
        Router = router;
    }


    private bool IsDarkTheme => Application.Current?.ActualThemeVariant == ThemeVariant.Dark;

    [ReactiveCommand]
    private void ToggleMenu()
    {
        IsMenuCollapsed = !IsMenuCollapsed;
    }

    [ReactiveCommand]
    private void ToggleTheme()
    {
        if (Application.Current is not null)
        {
            Application.Current.RequestedThemeVariant = IsDarkTheme 
                ? ThemeVariant.Light 
                : ThemeVariant.Dark;
            
            this.RaisePropertyChanged(nameof(ThemeIcon));
        }
    }
}

