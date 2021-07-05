using Pillbox.Database;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Environment = Android.OS.Environment;


[assembly: Dependency(typeof(SQLiteNotificationDb))]
namespace Pillbox.Droid.Persistance
{
    public class SQLiteNotificationDb : ISQLiteNotificationDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.DataDirectory.AbsolutePath.ToString();
            var path = Path.Combine(documentsPath, "MySQLiteNotification.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}