using System;
using ReactiveUI;

namespace SwitchPagesUserControl.ViewModels.Pages;

public abstract class BasePageViewModel : ReactiveObject, IRoutableViewModel
{
    public IScreen HostScreen { get; }
    
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];

    protected BasePageViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}