using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence
{
    public static class DatabaseConfig
    {
        public static string GetDatabasePath()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbFolder = Path.Combine(appDataPath, "MyWpfApp");
            Directory.CreateDirectory(dbFolder);
            return Path.Combine(dbFolder, "users.db");
        }
    }
}
