using System;
using System.Reactive;
using KrolikGR.Core.Mvvm;
using ReactiveUI;

namespace KrolikGR.Features.Shell.UI.Host;

public class HostViewModel : ViewModelBase
{


    public RoutingState Router { get; }
    public HostViewModel(RoutingState router)
    {
        Router = router;
       
    }

}
