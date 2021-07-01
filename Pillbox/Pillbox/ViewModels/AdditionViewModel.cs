using Pillbox.Database;
using Pillbox.Models;
using Pillbox.Services;
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
        private readonly IMedicineDatabase _medicineDatabase;
        private readonly IPageSevices _pageService;
        public Medicine Medicine { get; private set; }
        public ICommand SaveCommand { get; protected set; }
        public AdditionViewModel (MedicineViewModel medicineViewModel, IMedicineDatabase medicineDatabase, IPageSevices pageService)
        {
            if (medicineViewModel == null)
                throw new ArgumentNullException(nameof(medicineViewModel));

            _pageService = pageService;
            _medicineDatabase = medicineDatabase;

            SaveCommand = new Command(async () => await Save());

            Medicine = new Medicine
            {
                Id = medicineViewModel.Id,
                Title = medicineViewModel.Title,
                Format = medicineViewModel.Format,
                Method = medicineViewModel.Method,
                Duration = medicineViewModel.DurationVM,
                Frequency = medicineViewModel.FrequencyVM,
                Medication = medicineViewModel.MedicationVM
            };
        }
        
        async Task Save()
        {
           if(String.IsNullOrWhiteSpace(Medicine.Title))
            {
                await _pageService.DisplayAlert("Ошибка", "Пожалуйста, введите название лекарства", "OK");
                return;
            }
            if (String.IsNullOrWhiteSpace(Medicine.Format))
            {
                await _pageService.DisplayAlert("Ошибка", "Пожалуйста, выберите лекарственную форму", "OK");
                return;
            }
            if (String.IsNullOrWhiteSpace(Medicine.Method))
            {
                await _pageService.DisplayAlert("Ошибка", "Пожалуйста, введите форму приёма лекарства", "OK");
                return;
            }
            if (Medicine.Id==0)
            {
                await medicineDatabase.AddMedicine(Medicine);
                MessagingCenter.Send(this, Events.MedicineAdded, Medicine);
            }
            else
            {
                await medicineDatabase.UpdateMedicine(Medicine);
                MessagingCenter.Send(this, Events.MedicineUpdate, Medicine);
            }
            await _pageService.PopAsync();
        }
       
    }
}
