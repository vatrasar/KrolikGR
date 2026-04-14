using System;
using System.Reactive;
using KrolikGR.Src.Core.Mvvm;
using ReactiveUI;

namespace KrolikGR.Src.Features.Shell.UI.Host;

public class HostViewModel : ViewModelBase
{


    public RoutingState Router { get; }
    public HostViewModel(RoutingState router)
    {
        Router = router;
       
    }

}
