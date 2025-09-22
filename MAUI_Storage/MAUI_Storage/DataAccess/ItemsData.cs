
using SQLite;

namespace MAUI_Storage.Models
{
    public class ItemDatabase
    {
        public readonly SQLiteAsyncConnection _database;

        public ItemDatabase()
        {
            _database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            _database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.ItemId) ||
                string.IsNullOrWhiteSpace(item.ItemName) ||
                string.IsNullOrWhiteSpace(item.ItemDescription))
            {
                throw new Exception("All fields must be filled.");
            }

            return _database.InsertOrReplaceAsync(item);
        }
    }
}

