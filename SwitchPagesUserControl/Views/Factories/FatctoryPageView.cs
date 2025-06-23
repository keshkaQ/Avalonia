using System;
using System.Collections.Generic;
using ReactiveUI;
using SwitchPagesUserControl.ViewModels.Pages;
using SwitchPagesUserControl.Views.Pages;

namespace SwitchPagesUserControl.ViewModels;

public class FatctoryPageView:IViewLocator
{
    private readonly Dictionary<Type, IViewFor> _viewMappings = new()
    {
        { typeof(FirstPageViewModel), new FirstPage() },
        { typeof(SecondPageViewModel), new SecondPage() },
        { typeof(ThirdPageViewModel), new ThirdPage() },
    };

    public IViewFor ResolveView<T>(T viewModel, string? contract = null)
    {
        if (viewModel is BasePageViewModel pageViewModel)
        { 
            var pageView = _viewMappings[viewModel.GetType()];
            pageView.ViewModel ??= pageViewModel;
            
            return pageView;
        }
        
        throw new KeyNotFoundException($"No view registered for ViewModel type: {viewModel}");
    }
}