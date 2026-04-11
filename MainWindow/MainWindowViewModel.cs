namespace KrolikGR;
using KrolikGR.Core.Mvvm;
using KrolikGR.Features.Shell.UI.Shell;
using KrolikGR.Infrastructure;

public partial class MainWindowViewModel : ViewModelBase
{
    AppBootstrapper _appBootstrapper;
    public ShellViewModel ShellViewModel
    {
        get;
    }
    public MainWindowViewModel()
    {
        _appBootstrapper = new AppBootstrapper();
        ShellViewModel = new ShellViewModel(_appBootstrapper.Router);
    }
    
}
