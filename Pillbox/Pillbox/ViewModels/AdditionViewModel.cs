using Pillbox.Database;
using Pillbox.Models;
using Pillbox.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pillbox.ViewModels
{
    public class AdditionViewModel
    {
        private readonly IMedicineDatabase _medicineDatabase;
        private readonly IPageSevices _pageService;
        public Medicine Medicine { get; private set; }
        public ICommand SaveCommand { get; protected set; }
        public AdditionViewModel(MedicineViewModel medicineViewModel, IMedicineDatabase medicineDatabase, IPageSevices pageService)
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
                Duration = medicineViewModel.Duration,
                Frequency = medicineViewModel.Frequency,
                Medication = medicineViewModel.Medication
            };
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Medicine.Title))
            {
                await _pageService.DisplayAlert("Внимание", "Пожалуйста, введите название лекарства", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(Medicine.Format))
            {
                await _pageService.DisplayAlert("Внимание", "Пожалуйста, выберите единицы измерения", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(Medicine.Method))
            {
                await _pageService.DisplayAlert("Внимание", "Пожалуйста, выберите метод приёма", "OK");
                return;
            }

            //if (Medicine.InDays == default)
            
            //    Medicine.EveryDay = true;                
            
            //else Medicine.EveryDay = false;

                if (Medicine.InDays==default)
            {
                await _pageService.DisplayAlert("Внимание", "Пожалуйста, выберите частоту приёма", "OK");
                return;
            }
            if (Medicine.FinishMedicationTime <= Medicine.StartMedicationTime)
            {
                await _pageService.DisplayAlert("Внимание", "Время последнего приёма не может быть меньше времени первого", "OK");
                return;
            }
            string compareTemp_1 = Medicine.Number.ToString();
            if (string.IsNullOrWhiteSpace(compareTemp_1))
            {
                await _pageService.DisplayAlert("Внимание", "Выберите количество приёмов лекарства в день", "OK");
                return;
            }
            compareTemp_1 = Medicine.Dosage.ToString();
            if (string.IsNullOrWhiteSpace(compareTemp_1))
            {
                await _pageService.DisplayAlert("Внимание", "Выберите дозировку", "OK");
                return;
            }

            if (Medicine.Id == 0)
            {
                await _medicineDatabase.AddMedicine(Medicine);
                MessagingCenter.Send(this, Events.MedicineAdded, Medicine);
            }
            else
            {
                await _medicineDatabase.UpdateMedicine(Medicine);
                MessagingCenter.Send(this, Events.MedicineUpdate, Medicine);
            }
            await _pageService.PopAsync();
        }

    }
}
