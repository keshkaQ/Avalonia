using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SwitchPagesUserControl.ViewModels.Pages;

namespace SwitchPagesUserControl.Views.Pages;

public partial class ThirdPage : ReactiveUserControl<ThirdPageViewModel>
{
    public ThirdPage()
    {
        InitializeComponent();
    }
}