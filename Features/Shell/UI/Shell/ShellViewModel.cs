using System;
using System.Reactive;
using KrolikGR.Core.Mvvm;
using ReactiveUI;

namespace KrolikGR.Features.Shell.UI.Shell;

public class ShellViewModel : ViewModelBase
{


    public RoutingState Router { get; }
    public ShellViewModel(RoutingState router)
    {
        Router = router;
       
    }

}
