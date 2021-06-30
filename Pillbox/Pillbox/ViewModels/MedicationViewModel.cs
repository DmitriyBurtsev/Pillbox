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
        public DateTime StartMedicationTime
        {
            get => _medication.StartMedicationTime;
            set => Set(ref _medication.StartMedicationTime, value);
        }
        public DateTime FinishMedicationTime
        {
            get => _medication.FinishMedicationTime;
            set => Set(ref _medication.FinishMedicationTime, value);
        }

        public float Dosage
        {
            get => _medication.Dosage;
            set => Set(ref _medication.Dosage, value);
        }   
        
        public int Number
        {
            get => _medication.Number;
            set => Set(ref _medication.Number, value);
        }
    }
}
