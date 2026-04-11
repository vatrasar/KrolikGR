namespace KrolikGR;
using KrolikGR.Core.Mvvm;
using KrolikGR.Features.Shell.UI.Host;
using KrolikGR.Infrastructure;

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
