using System.Reactive;
using ReactiveUI;
using SwitchPagesUserControl.ViewModels.Factories;
using SwitchPagesUserControl.ViewModels.Pages;

namespace SwitchPagesUserControl.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();
    
    public ReactiveCommand<Unit, IRoutableViewModel> GoFirstPage { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoSecondPage { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoThirdPage { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }

    public MainWindowViewModel()
    {
        var factoryPageViewModel = new FactoryPageViewModel(this);

        GoFirstPage = factoryPageViewModel.CreateNavigationCommand<FirstPageViewModel>();
        GoSecondPage = factoryPageViewModel.CreateNavigationCommand<SecondPageViewModel>();
        GoThirdPage = factoryPageViewModel.CreateNavigationCommand<ThirdPageViewModel>();
        GoBack = factoryPageViewModel.CreateBackCommand();
        
        GoFirstPage.Execute();
    }
}