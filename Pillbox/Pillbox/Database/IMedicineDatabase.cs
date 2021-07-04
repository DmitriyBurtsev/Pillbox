using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pillbox.Database
{
    public interface IMedicineDatabase
    {
        
        Task<IEnumerable<Medicine>> UpdateMedicineList();
        Task<Medicine> GetMedicine(int id);
        Task AddMedicine(Medicine contact);
        Task UpdateMedicine(Medicine contact);
        Task DeleteMedicine(Medicine contact);
    }
}

