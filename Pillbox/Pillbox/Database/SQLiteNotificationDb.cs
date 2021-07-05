using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pillbox.Database
{
    public class SQLiteNotificationDb : ISQLiteNotificationDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLiteNotification.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
