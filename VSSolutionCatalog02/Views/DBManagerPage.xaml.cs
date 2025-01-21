using Microsoft.UI.Xaml.Controls;

using VSSolutionCatalog02.ViewModels;

namespace VSSolutionCatalog02.Views;

public sealed partial class DBManagerPage : Page
{
    public DBManagerViewModel ViewModel
    {
        get;
    }

    public DBManagerPage()
    {
        ViewModel = App.GetService<DBManagerViewModel>();
        InitializeComponent();
    }
}
