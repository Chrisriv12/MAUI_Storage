using MAUI_Storage.Models;

namespace MAUI_Storage;

public partial class MainPage : ContentPage
{
    public readonly ItemDatabase _database;

    public MainPage()
    {
        InitializeComponent();
        _database = new ItemDatabase();
        LoadItems();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var id = ItemIdEntry.Text?.Trim();
        var name = ItemNameEntry.Text?.Trim();
        var desc = ItemDescEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(id) ||
            string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(desc))
        {
            await DisplayAlert("Error", "Please enter all fields before saving.", "OK");
            return;
        }

        var item = new Item
        {
            ItemId = id,
            ItemName = name,
            ItemDescription = desc
        };

        try
        {
            await _database.SaveItemAsync(item);
            ClearFields();
            LoadItems();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void LoadItems()
    {
        var items = await _database.GetItemsAsync();
        ItemsList.ItemsSource = items;
    }

    private void ClearFields()
    {
        ItemIdEntry.Text = "";
        ItemNameEntry.Text = "";
        ItemDescEntry.Text = "";
    }
}

