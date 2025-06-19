using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PagesViewModel;

namespace PagesView;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ManagerMovieViewModel();
    }
}