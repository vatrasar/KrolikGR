namespace KrolikGR;
using KrolikGR.Src.Core.Mvvm;
using KrolikGR.Src.Features.Shell.UI.Host;
using KrolikGR.Src.Infrastructure;

public partial class MainWindowViewModel : ViewModelBase
{
    AppBootstrapper _appBootstrapper;
    public HostViewModel HostViewModel
    {
        get;
    }
    public MainWindowViewModel()
    {
        _appBootstrapper = new AppBootstrapper();
        HostViewModel = new HostViewModel(_appBootstrapper.Router);
    }
    
}
