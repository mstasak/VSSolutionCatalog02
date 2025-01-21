using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using VSSolutionCatalog02.ViewModels;

namespace VSSolutionCatalog02.Views;

public sealed partial class ListDetailsPage : Page
{
    public ListDetailsViewModel ViewModel
    {
        get;
    }

    public ListDetailsPage()
    {
        ViewModel = App.GetService<ListDetailsViewModel>();
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
