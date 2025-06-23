using ReactiveUI;

namespace SwitchPagesUserControl.ViewModels.Pages;

public class FirstPageViewModel:BasePageViewModel
{
    public string Text { get; set; }
    public FirstPageViewModel(IScreen screen) : base(screen)
    {
        
    }
}