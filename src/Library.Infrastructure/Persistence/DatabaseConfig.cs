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
            // Get the directory where the executing assembly is located
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            
            // Navigate to the Persistence folder
            // Assumes you're running from bin\Debug\net9.0\ or similar
            string persistenceFolder = Path.GetFullPath(Path.Combine(baseDirectory, "..", "..", "..", "Persistence"));
            
            // Ensure the directory exists
            Directory.CreateDirectory(persistenceFolder);
            
            // Return the full path to the database file
            //return Path.Combine(persistenceFolder, "library.db");

            return "library.db";
        }
    }
}
