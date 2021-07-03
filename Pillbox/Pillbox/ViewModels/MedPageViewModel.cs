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
using Pillbox.Services;
using System.Linq;

namespace Pillbox.ViewModels
{
    public class MedPageViewModel:BaseViewModel
    {
        public ICommand AddMedicineCommand { get; protected set; }
        public ICommand DeleteMedicineCommand { get; protected set; }
        public ICommand SelectMedicineCommand { get; protected set; }
        public ICommand LoadMedicinesCommand { get; protected set; }

        private bool _isDataLoaded;

        private IMedicineDatabase _medicineDB;
        private IPageSevices _pageService;
        //private INotificationManager _notificationManager; // локальные уведомления

        private MedicineViewModel _selectedMedicine;
        public MedicineViewModel SelectedMedicine
        {
            get => _selectedMedicine;
            set
            {
                Set(ref _selectedMedicine, value);
            }
        }

        public ObservableCollection<MedicineViewModel> Medicines { get; set; }
            = new ObservableCollection<MedicineViewModel>();
        
        

        

        public MedPageViewModel(IPageSevices pageSevices, IMedicineDatabase medicineDatabase)
        {
            _pageService = pageSevices;
            _medicineDB = medicineDatabase;
            //_notificationManager = DependencyService.Get<INotificationManager>(); // локальные уведомления

            // _medicines = new ObservableCollection<MedicineViewModel>();

            LoadMedicinesCommand = new Command(async () => await Load());
            AddMedicineCommand = new Command(async () => await AddMedicine());
            DeleteMedicineCommand = new Command<MedicineViewModel>(async c => await DeleteMedicine(c));
            SelectMedicineCommand = new Command<MedicineViewModel>(async c => await SelectMedicine(c));

            MessagingCenter.Subscribe<AdditionViewModel, Medicine>
                (this, Events.MedicineAdded, OnMedicineAdded);
            MessagingCenter.Subscribe<AdditionViewModel, Medicine>
                (this, Events.MedicineUpdate, OnMedicineUpdated);            
        }


        private void OnMedicineUpdated(AdditionViewModel source, Medicine medicine)
        {
            var medicineInList = Medicines.Single(c => c.Id == medicine.Id);
            medicineInList.Id = medicine.Id;
            medicineInList.Dosage = medicine.Dosage;
            medicineInList.DurationDays = medicine.DurationDays;
            medicineInList.EveryDay = medicine.EveryDay;
            medicineInList.Finish = medicine.Finish;
            medicineInList.FinishMedicationTime = medicine.FinishMedicationTime;
            medicineInList.Format = medicine.Format;
            medicineInList.InDays = medicine.InDays;
            medicineInList.Method = medicine.Method;
            medicineInList.NonStop = medicine.NonStop;
            medicineInList.Number = medicine.Number;
            medicineInList.Start = medicine.Start;
            medicineInList.StartMedicationTime = medicine.StartMedicationTime;
            medicineInList.Title = medicine.Title;
        }

        private void OnMedicineAdded(AdditionViewModel source, Medicine medicine)
        {
            Medicines.Add(new MedicineViewModel(medicine));
        }

        private async Task SelectMedicine(MedicineViewModel medicine)
        {
            if (medicine == null) 
                return;
            SelectedMedicine = null;
            await _pageService.PushAsync(new AdditionView(medicine));
        }

        private async Task Load()
        {
            Medicines.Clear();
            try
            {
                if (_isDataLoaded)
                    return;
                _isDataLoaded = true;
                var medicines = await _medicineDB.UpdateMedicineList();
                foreach (var medicine in medicines)
                    Medicines.Add(new MedicineViewModel(medicine));
            }
            catch (Exception)
            { throw; }

        }

        async Task AddMedicine()
        {
            await _pageService.PushAsync(new AdditionView(new MedicineViewModel()));
        }

        async Task DeleteMedicine(MedicineViewModel deleteMedicine)
        {
            if (await _pageService.DisplayAlert("Внимание", $"Вы действительно хотите удалить {deleteMedicine.Title}?", "Да", "Нет"))
            {
                Medicines.Remove(deleteMedicine);
                var medicine = await _medicineDB.GetMedicine(deleteMedicine.Id); // поиск medicine в базе по его ID
                await _medicineDB.DeleteMedicine(medicine);
            }
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
