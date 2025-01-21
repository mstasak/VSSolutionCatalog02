using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VSSolutionCatalog02.Core.Models;

namespace VSSolutionCatalog02.ViewModels;

public partial class DBManagerViewModel : ObservableRecipient
{
    //string dbaUsername = string.Empty;
    //string dbaPassword = string.Empty;

    private void TestConnectToDatabase() {
        //test the db connection
        var (success, message) = AppDbContext.TestConnection();
        StatusMessage = success ? "Success!" : $"Failure: {message}.";
    }

    public ICommand TestConnectCommand { get; }
    public ICommand PopulateDataCommand { get; }
    public ICommand DeleteDataCommand { get; }
    public ICommand ViewDataCommand { get; }

    private string statusMessage = "";

    public string StatusMessage {
        get => statusMessage;
        set => SetProperty(ref statusMessage, value);
    }

    public DBManagerViewModel()
    {
        TestConnectCommand = new RelayCommand(TestConnectToDatabase);
        PopulateDataCommand = new RelayCommand(PopulateData);
        DeleteDataCommand = new RelayCommand(DeleteData);
        ViewDataCommand = new RelayCommand(ViewData);
    }

    private void PopulateData() {
        var (success, message) = AppDbContext.Shared.PopulateData();
        StatusMessage = success
            ? $"Success: {message}."
            : $"Failure: {message}.";
    }

    private void DeleteData() {
        var (success, message) = AppDbContext.Shared.DeleteData();
        StatusMessage = success
            ? $"Success: {message}."
            : $"Failure: {message}.";
    }

    private void ViewData() {
        var data = AppDbContext.Shared.FetchData();
        StatusMessage = data;
    }

}
