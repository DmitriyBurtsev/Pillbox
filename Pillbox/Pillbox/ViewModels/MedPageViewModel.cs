using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Pillbox.Views.MainViews;
using Pillbox.Database;
using System.Threading.Tasks;
using Pillbox.Models;
using Pillbox.Views.AdditionView;

namespace Pillbox.ViewModels
{
    public class MedPageViewModel:MedicineViewModel
    {
        public ICommand AddMedicineCommand { get; protected set; }
        public ICommand DeleteMedicineCommand { get; protected set; }
        public MedPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            medicineDatabase = new MedicineDatabase();
            AddMedicineCommand = new Command(async () => await AddMedicine());
            DeleteMedicineCommand = new Command(async () => await DeleteMedicine());
            UploatAllMedicines();
        }
        async void UploatAllMedicines()
        {
            MedicineList = await medicineDatabase.GetMedicinesAsync();
        }

        //public ObservableCollection<MedicineViewModel> medicines;

        //public MedPageViewModel()
        //{
        //    medicines = new ObservableCollection<MedicineViewModel>();
        //   
        //    SaveChangesCommand = new Command<MedicineViewModel>(async m =>await SaveChanges(m));
        //    BackCommand = new Command(Back);
        //}

        Medicine selectedMedicine;
        public Medicine SelectedMedicine
        {
            get => selectedMedicine;
            set
            {
                Set(ref selectedMedicine, value);
                ShowMedicineDetails(value.Id);
            }
        }
        async void ShowMedicineDetails(int selectedMedicineId)
        {
            await Navigation.PushAsync(new DetailsPage(selectedMedicineId));
        }
        async Task AddMedicine()
        {
           await Navigation.PushAsync(new AdditionView());
        }
       
        async Task DeleteMedicine()
        {
           await medicineDatabase.DeleteMedicineAsync(medicine.Id);
        }


        //public void Back()
        //{
        //    Navigation.PopAsync();
        //}
        //async Task SaveChanges()
        //{            
        //    await medicineDatabase.SaveMedicineAsync(medicine);
        //}
    }
}
