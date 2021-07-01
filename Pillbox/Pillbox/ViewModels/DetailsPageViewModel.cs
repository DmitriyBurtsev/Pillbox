using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pillbox.ViewModels
{
    public class DetailsPageViewModel:MedicineViewModel
    {
        public ICommand SaveChangesCommand;
        public ICommand DeleteMedicineCommand;
        public DetailsPageViewModel (INavigation navigation, int selectedMedicineId)
        {
            Navigation = navigation;
            //medicine = new Models.Medicine();
            //medicine.Id = selectedMedicineId;
            medicineDatabase = new Database.MedicineDatabase(App.dbpath);

            SaveChangesCommand = new Command(async () => await SaveChanges());
            DeleteMedicineCommand = new Command(async () => await DeleteMedicine());

            ShowMedicineDetails();
        }        
        async void ShowMedicineDetails()
        {
            medicine = await medicineDatabase.GetMedicineAsync(medicine.Id);
        }
        async Task SaveChanges()
        {
            await medicineDatabase.SaveMedicineAsync(medicine);
            await Navigation.PopAsync();
        }
        async Task DeleteMedicine()
        {
            await medicineDatabase.GetMedicineAsync(medicine.Id);
        }
    }
}
