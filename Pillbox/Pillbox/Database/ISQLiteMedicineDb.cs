using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.Database
{
    public interface ISQLiteMedicineDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
