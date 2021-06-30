using Pillbox.Database;
using Pillbox.Models;
using Pillbox.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pillbox.ViewModels
{
    public class AdditionViewModel:MedicineViewModel
    {
       public ICommand SaveCommand { get; protected set; }
        public AdditionViewModel (INavigation navigation)
        {
            Navigation = navigation;
            medicine = new Medicine();
            medicineDatabase = new MedicineDatabase();
            SaveCommand = new Command(async () => await Save());
        }
        
        async Task Save()
        {
            if (medicine.Format != null && medicine.Method != null && medicine.Title != null
                && medicine.Duration.Start != null && (medicine.Frequency.EveryDay == true || medicine.Frequency.InDays >= 2)
                && medicine.Medication.Dosage >= 0.5 && medicine.Medication.StartMedicationTime != null
                && medicine.Medication.FinishMedicationTime != null && medicine.Medication.Number >= 1)
            {
                await medicineDatabase.SaveMedicineAsync(medicine);
                await Navigation.PushAsync(new MedPage());                
            }
            
        }
       
    }
}
