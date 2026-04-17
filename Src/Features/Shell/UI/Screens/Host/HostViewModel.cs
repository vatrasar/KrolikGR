using System;
using System.Reactive;
using KrolikGR.Src.Core.Mvvm;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace KrolikGR.Src.Features.Shell.UI.Screens.Host;

public partial class HostViewModel : ViewModelBase, IScreen
{
    [Reactive]
    private bool _isMenuCollapsed;

    public RoutingState Router { get; }

    public HostViewModel(RoutingState router)
    {
        Router = router;
    }

    [ReactiveCommand]
    private void ToggleMenu()
    {
        IsMenuCollapsed = !IsMenuCollapsed;
    }
}
