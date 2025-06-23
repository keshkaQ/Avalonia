using ReactiveUI;

namespace SwitchPagesUserControl.ViewModels.Pages;

public class SecondPageViewModel:BasePageViewModel
{
    public string Text { get; set; }
    public SecondPageViewModel(IScreen screen) : base(screen)
    {
        
    }
}