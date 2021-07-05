using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pillbox.Database
{
    public class SQLiteMedicineDb : ISQLiteMedicineDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
