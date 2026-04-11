using Splat;

namespace KrolikGR.Core.Infrastructure;

public interface IFeatureModule
{
    void Register(IMutableDependencyResolver services);
}