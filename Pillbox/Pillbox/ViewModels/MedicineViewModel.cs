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
            StartMedicationTime = medicine.StartMedicationTime;
            FinishMedicationTime = medicine.FinishMedicationTime;
            Dosage = medicine.Dosage;
            Number = medicine.Number;
            Start = medicine.Start;
            DurationDays = medicine.DurationDays;
            Finish = medicine.Finish;
            EveryDay = medicine.EveryDay;
            InDays = medicine.InDays;
            NonStop = medicine.NonStop;

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
        private DateTime _startMedicationTime;
        public DateTime StartMedicationTime
        {
            get => _startMedicationTime;
            set => Set(ref _startMedicationTime, value);
        }
        private DateTime _finishMedicationTime;
        public DateTime FinishMedicationTime
        {
            get => _finishMedicationTime;
            set => Set(ref _finishMedicationTime, value);
        }
        private float _dosage;
        public float Dosage
        {
            get => _dosage;
            set => Set(ref _dosage, value);
        }
        private int _number;
        public int Number 
        { 
            get=>_number; 
            set=>Set(ref _number, value); 
        }
        private DateTime _start;
        public DateTime Start { get=>_start; set=>Set(ref _start, value); }
        private int _durationDays;
        public int DurationDays { get=> _durationDays; set=>Set(ref _durationDays, value); }
        private DateTime _finish;
        public DateTime Finish { get=> _finish; set=>Set(ref _finish, value); }
        private bool _everyDay;
        public bool EveryDay { get=> _everyDay; set=>Set(ref _everyDay, value); }
        private int _inDays;
        public int InDays { get=> _inDays; set=>Set(ref _inDays, value); }
        private bool _nonStop;
        public bool NonStop { get=> _nonStop; set=>Set(ref _nonStop, value); }

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
