using Microsoft.UI.Xaml.Controls;

using VSSolutionCatalog02.ViewModels;

namespace VSSolutionCatalog02.Views;

public sealed partial class BlankPage : Page
{
    public BlankViewModel ViewModel
    {
        get;
    }

    public BlankPage()
    {
        ViewModel = App.GetService<BlankViewModel>();
        InitializeComponent();
    }
}
