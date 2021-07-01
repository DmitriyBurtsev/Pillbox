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
        public ICommand SelectMedicineCommand { get; protected set; }
        public ICommand LoadMedicinesCommand { get; protected set; }

        private bool _isDataLoaded;

        private MedicineViewModel _selectedMedicine;
        public MedicineViewModel SelectedMedicine
        {
            get => _selectedMedicine;
            set
            {
                Set(ref _selectedMedicine, value);
                ShowMedicineDetails(value.Id);
            }
        }

        public ObservableCollection<MedicineViewModel> Medicines { get; private set; } 
            = new ObservableCollection<MedicineViewModel>();
        public MedPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            //medicineDatabase = new MedicineDatabase(App.dbpath);
            //Medicines = new List<MedicineViewModel>();
            LoadMedicinesCommand = new Command(async () => await Load());
            AddMedicineCommand = new Command(async () => await AddMedicine());
            DeleteMedicineCommand = new Command(async () => await DeleteMedicine());
            SelectMedicineCommand = new Command(async () => await SelectMedicine());
            //UploatAllMedicines();            
        }

        private async Task SelectMedicine(MedicineViewModel medicine)
        {
            if (medicine == null) 
                return;
            SelectedMedicine = null;
            await Navigation.PushAsync(new DetailsPageViewModel(medicine));
        }

        private async Task Load()
        {
           if(_isDataLoaded)
                return;
            _isDataLoaded = true;
            var medicines = await medicineDatabase.GetAllMedicinesAsync();
            foreach (var medicine in medicines)
                Medicines.Add(new MedicineViewModel(medicine));
        }

        //async void UploatAllMedicines()
        //{
        //    MedicineList = await medicineDatabase.GetMedicinesAsync();
        //}

        //public ObservableCollection<MedicineViewModel> medicines;

        //public MedPageViewModel()
        //{
        //    medicines = new ObservableCollection<MedicineViewModel>();
        //   
        //    SaveChangesCommand = new Command<MedicineViewModel>(async m =>await SaveChanges(m));
        //    BackCommand = new Command(Back);
        //}

        //async void ShowMedicineDetails(int selectedMedicineId)
        //{
        //    await Navigation.PushAsync(new DetailsPage(selectedMedicineId));
        //}
        async Task AddMedicine()
        {
           await Navigation.PushAsync(new AdditionView(new MedicineViewModel));
        }
       
        async Task DeleteMedicine()
        {
           await medicineDatabase.DeleteMedicineAsync(_selectedMedicine.Id);
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
