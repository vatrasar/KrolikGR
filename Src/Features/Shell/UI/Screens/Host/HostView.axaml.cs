using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace KrolikGR.Src.Features.Shell.UI.Screens.Host;

/// <summary>
/// # Host Screen
/// 
/// ## Purpose
/// The Host screen is the main shell of the application. It provides the main navigation menu and hosts the `RoutedViewHost` where other screens are displayed.
/// 
/// ## Functionalities
/// - **Main Navigation Menu**: A sidebar menu that allows users to navigate between different features of the application.
/// - **Menu Collapsing**: The sidebar menu can be collapsed to save space or expanded to show text labels.
/// - **Theme Switching**: A button in the sidebar that toggles the application's theme between Light and Dark modes.
/// - **Routing Host**: Contains the `rxui:RoutedViewHost` which manages the display of child screens based on the current navigation state.
/// 
/// ## Key UI Elements
/// - **ToggleMenuButton**: Collapses/Expands the sidebar menu.
/// - **ToggleThemeButton**: Changes the application's visual theme (Material Icons: Sunny/Night).
/// - **Navigation Buttons**: Home, Account, Settings (currently placeholders).
/// - **RoutedViewHost**: The area where the content of the active screen is rendered.
/// 
/// ## Navigation (From)
/// - None — this is the root entry-point screen, loaded directly at application startup. It is not navigated to via routing.
/// 
/// ## Navigation (To)
/// - **ScheduleCalendarView** — pushed directly onto the `Router.NavigationStack` during `HostViewModel` initialization.
/// </summary>
public partial class HostView : ReactiveUserControl<HostViewModel>
{

    public HostView()
    {
        InitializeComponent();
        this.WhenActivated(disposables => 
        { 
            
        });
    }

}