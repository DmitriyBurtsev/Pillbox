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
        public Medicine medicine;
        public INavigation Navigation;
        public MedicineDatabase medicineDatabase;
        public MedicationViewModel medicationVM;
        public MedicationViewModel MedicationVM
        {
            get => medicationVM;
            set => Set(ref medicationVM, value);
        }
        public DurationViewModel durationVM;
        public DurationViewModel DurationVM
        {
            get => durationVM;
            set => Set(ref durationVM, value);
        }
        public FrequencyViewModel frequencyVM;
        public FrequencyViewModel FrequencyVM
        {
            get => frequencyVM;
            set => Set(ref frequencyVM, value);
        }


        //public MedPageViewModel medPageViewModel;
        //public MedPageViewModel ListViewModel
        //{
        //    get => medPageViewModel;
        //    set => Set(ref medPageViewModel, value);
        //}
        //public MedicineViewModel()
        //{
        //    medicine = new Medicine();
        //}
        public string Title
        {
            get => medicine.Title;
            set => Set(ref medicine.Title, value);
        }
        public string Format
        {
            get => medicine.Format;
            set => Set(ref medicine.Format, value);
        }
        public string Method
        {
            get => medicine.Method;
            set => Set(ref medicine.Method, value);
        }
        public ObservableCollection<Medication> Medications
        {
            get => medicine.medications;
            set => Set(ref medicine.medications, value);
        }
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
        List<Medicine> medicineList;
        public List<Medicine> MedicineList
        {
            get => medicineList;
            set => Set(ref medicineList, value);
        }
    }
}
