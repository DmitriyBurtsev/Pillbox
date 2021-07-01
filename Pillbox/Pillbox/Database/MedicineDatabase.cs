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
        static SQLiteAsyncConnection medicineDatabase;

        public MedicineDatabase(string dbPath)
        {
            medicineDatabase = new SQLiteAsyncConnection(dbPath);
            
        }
        public async Task CreateTable()
        {
            await medicineDatabase.CreateTableAsync<Medicine>();
        }
        public async Task<IEnumerable<Medicine>> GetAllMedicinesAsync()
        {
            return await medicineDatabase.Table<Medicine>().ToListAsync();
        }
        public async Task<Medicine> GetMedicineAsync(int id)
        {
            return await medicineDatabase.GetAsync<Medicine>(id);
        }
        public async Task<int> DeleteMedicineAsync(int id)
        {
            return await medicineDatabase.DeleteAsync(id);
        }
        public async Task<int> SaveMedicineAsync(Medicine item)
        {
            if (item.Id != 0)
            {
                await medicineDatabase.UpdateAsync(item);
                return item.Id;
            }
            else return await medicineDatabase.InsertAsync(item);
        }
    }
}
