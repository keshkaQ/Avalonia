using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SwitchPagesUserControl.ViewModels.Pages;

namespace SwitchPagesUserControl.Views.Pages;

public partial class FirstPage : ReactiveUserControl<FirstPageViewModel>
{
    public FirstPage()
    {
        InitializeComponent();
    }
}