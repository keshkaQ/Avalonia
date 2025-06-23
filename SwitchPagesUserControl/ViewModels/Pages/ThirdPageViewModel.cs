using ReactiveUI;

namespace SwitchPagesUserControl.ViewModels.Pages;

public class ThirdPageViewModel:BasePageViewModel
{
    public string Text { get; set; }
    public ThirdPageViewModel(IScreen screen) : base(screen)
    {
        
    }
}