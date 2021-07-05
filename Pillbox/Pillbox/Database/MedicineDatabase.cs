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
    public class MedicineDatabase:IMedicineDatabase
    {
        private SQLiteAsyncConnection _connection;

        public MedicineDatabase(ISQLiteMedicineDb db)
        {
            _connection = db.GetConnection();
           // _connection.DropTableAsync<Medicine>(); // удаление БД
            _connection.CreateTableAsync<Medicine>();
        }
       

        public async Task<IEnumerable<Medicine>> UpdateMedicineList()
        {
            return await _connection.Table<Medicine>().ToListAsync();
        }

        public async Task<Medicine> GetMedicine(int id)
        {
            return await _connection.FindAsync<Medicine>(id);
        }

        public  async Task AddMedicine(Medicine contact)
        {
            await _connection.InsertAsync(contact);
        }

        public async Task UpdateMedicine(Medicine contact)
        {
            await _connection.UpdateAsync(contact);
        }

        public async Task DeleteMedicine(Medicine contact)
        {
            await _connection.DeleteAsync(contact);
        }       
    }
}
