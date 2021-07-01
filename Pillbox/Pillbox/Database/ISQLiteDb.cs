using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.Database
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
