using KrolikGR.Src.Core.Infrastructure;
using KrolikGR.Src.Features.Shell;
using ReactiveUI;
using Splat;
using System.Collections.Generic;

namespace KrolikGR.Src.Infrastructure;

public class AppBootstrapper : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new RoutingState();

    public AppBootstrapper()
    {
        Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
        RegisterModules();
    }

    private void RegisterModules()
    {
        var modules = new List<IFeatureModule>
        {
            
        };

        foreach (var module in modules)
        {
            module.Register(Locator.CurrentMutable);
        }
    }
}