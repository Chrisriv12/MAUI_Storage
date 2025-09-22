using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Storage.Models
{
    public static class DatabaseConstants
    {
        public const string DatabaseFile = "Items.db3";

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite
            | SQLite.SQLiteOpenFlags.Create
            | SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFile);
        
    }
}
