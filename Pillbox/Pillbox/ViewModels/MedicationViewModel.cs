using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pillbox.ViewModels
{
    public class MedicationViewModel:BaseViewModel
    {
        public Medication _medication;
        public DateTime MedicationTime
        {
            get => _medication.MedicationTime;
            set => Set(ref _medication.MedicationTime, value);
        }

        public float Dosage
        {
            get => _medication.Dosage;
            set => Set(ref _medication.Dosage, value);
        }
       
    }
}
