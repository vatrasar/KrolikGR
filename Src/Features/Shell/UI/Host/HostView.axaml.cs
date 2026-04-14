using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace KrolikGR.Src.Features.Shell.UI.Host;

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