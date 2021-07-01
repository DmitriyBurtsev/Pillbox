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
           // medicine = new Medicine();
            medicineDatabase = new MedicineDatabase(App.dbpath);
            SaveCommand = new Command(async () => await Save());
        }
        
        async Task Save()
        {
            {
                await medicineDatabase.SaveMedicineAsync(medicine);
                await Navigation.PopAsync();                
            }
            
        }
       
    }
}
