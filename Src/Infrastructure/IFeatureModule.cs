using Splat;

namespace KrolikGR.Src.Core.Infrastructure;

public interface IFeatureModule
{
    void Register(IMutableDependencyResolver services);
}