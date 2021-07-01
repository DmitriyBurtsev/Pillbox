using System;
using System.Collections.Generic;
using System.Text;
using Pillbox.Models;
using Pillbox.Database;
using System.Collections.ObjectModel;
using System.Windows;
using Pillbox.Views;
using Xamarin.Forms;

namespace Pillbox.ViewModels
{
    public class MedicineViewModel:BaseViewModel
    {
        public INavigation Navigation;
        public MedicineDatabase medicineDatabase;

        //public MedPageViewModel medPageViewModel;
        //public MedPageViewModel ListViewModel
        //{
        //    get => medPageViewModel;
        //    set => Set(ref medPageViewModel, value);
        //}
        public MedicineViewModel() { }
        public MedicineViewModel(Medicine medicine)
        {
            Id = medicine.Id;
            Title = medicine.Title;
            Format = medicine.Format;
            Method = medicine.Method;
            DurationVM = medicine.Duration;
            FrequencyVM = medicine.Frequency;
            MedicationVM = medicine.Medication;
        }
        public int Id { get; set; }
        private string _title; 
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        private string _format;
        public string Format
        {
            get => _format;
            set => Set(ref _format, value);
        }
        private string _method;
        public string Method
        {
            get => _method;
            set => Set(ref _method, value);
        }
        public MedicationViewModel _medicationVM;
        public MedicationViewModel MedicationVM
        {
            get => _medicationVM;
            set => Set(ref _medicationVM, value);
        }
        public DurationViewModel _durationVM;
        public DurationViewModel DurationVM
        {
            get => _durationVM;
            set => Set(ref _durationVM, value);
        }
        public FrequencyViewModel _frequencyVM;
        public FrequencyViewModel FrequencyVM
        {
            get => _frequencyVM;
            set => Set(ref _frequencyVM, value);
        }



        //public ObservableCollection<Medication> Medications
        //{
        //    get => medicine.medications;
        //    set => Set(ref medicine.medications, value);
        //}
        //public Duration duration
        //{
        //    get => medicine.duration;
        //    set => Set(ref medicine.duration, value);
        //}
        //public Frequency frequency
        //{
        //    get => medicine.frequency;
        //    set => Set(ref medicine.frequency, value);
        //}
        //public List<Medicine> medicineList;
        //public List<Medicine> MedicineList
        //{
        //    get => medicineList;
        //    set => Set(ref medicineList, value);
        //}
    }
}
