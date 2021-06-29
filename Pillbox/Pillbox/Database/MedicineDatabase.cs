using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using System.Threading.Tasks;
using Pillbox.Models;
using System.IO;

namespace Pillbox.Database
{
    public class MedicineDatabase
    {
        static SQLiteAsyncConnection sqliteconection;
        public const string DbFileName = "medicines.db";

        public MedicineDatabase()
        {
            sqliteconection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbFileName));
            sqliteconection.CreateTableAsync<Medicine>();
        }
       
        public async Task<List<Medicine>> GetMedicinesAsync()
        {
            return await sqliteconection.Table<Medicine>().ToListAsync();
        }
        public async Task<Medicine> GetMedicineAsync(int id)
        {
            return await sqliteconection.GetAsync<Medicine>(id);
        }
        public async Task<int> DeleteMedicineAsync(int id)
        {
            return await sqliteconection.DeleteAsync(id);
        }
        public async Task<int> SaveMedicineAsync(Medicine item)
        {
            if (item.Id != 0)
            {
                await sqliteconection.UpdateAsync(item);
                return item.Id;
            }
            else return await sqliteconection.InsertAsync(item);
        }
    }
}
