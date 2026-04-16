using KrolikGR.Src.Core.Infrastructure;
using KrolikGR.Src.Features.Shell;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        var featureModuleType = typeof(IFeatureModule);
        var moduleTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => featureModuleType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var type in moduleTypes)
        {
            
            if (Activator.CreateInstance(type) is IFeatureModule module)
            {
                module.Register(Locator.CurrentMutable);
            }
        }
    }
}