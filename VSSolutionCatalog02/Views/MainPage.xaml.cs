using Microsoft.UI.Xaml.Controls;

using VSSolutionCatalog02.ViewModels;

namespace VSSolutionCatalog02.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
