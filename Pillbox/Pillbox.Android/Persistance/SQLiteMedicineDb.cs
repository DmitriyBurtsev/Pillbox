using Pillbox.Database;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Environment = Android.OS.Environment;

[assembly: Dependency(typeof(SQLiteMedicineDb))]
namespace Pillbox.Droid.Persistance
{
    public class SQLiteMedicineDb : ISQLiteMedicineDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.DataDirectory.AbsolutePath.ToString();
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}