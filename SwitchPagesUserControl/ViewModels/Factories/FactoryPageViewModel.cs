using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using SwitchPagesUserControl.ViewModels.Pages;

namespace SwitchPagesUserControl.ViewModels.Factories;

public class FactoryPageViewModel
{
    private readonly Dictionary<Type, BasePageViewModel> _pageViewModelsByType;
    private readonly IScreen _screen;
    public FactoryPageViewModel(IScreen screen)
    {
        _screen = screen;
        
        _pageViewModelsByType = new Dictionary<Type, BasePageViewModel>
        {
            { typeof(FirstPageViewModel), new FirstPageViewModel(screen) },
            { typeof(SecondPageViewModel), new SecondPageViewModel(screen) },
            { typeof(ThirdPageViewModel), new ThirdPageViewModel(screen) }
        };
    }

    public ReactiveCommand<Unit, IRoutableViewModel> CreateNavigationCommand<T>() where T : BasePageViewModel
    {
        var pageViewModel = _pageViewModelsByType[typeof(T)];
        
        return ReactiveCommand.CreateFromObservable(
            () => _screen.Router.Navigate.Execute(pageViewModel)
        );
    }
    
    public ReactiveCommand<Unit, IRoutableViewModel> CreateBackCommand()
    {
        return ReactiveCommand.CreateFromObservable(
            () => _screen.Router.NavigateBack.Execute(),
            _screen.Router.NavigateBack.CanExecute
        );
    }
}