using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pillbox.ViewModels
{
    public class MedicationViewModel : BaseViewModel
    {
        public MedicationViewModel(Medication medication)
        {
            StartMedicationTime = medication.StartMedicationTime;
            FinishMedicationTime = medication.FinishMedicationTime;
            Dosage = medication.Dosage;
            Number = medication.Number;
        }
        private DateTime _startMedication;
        public DateTime StartMedicationTime
        {
            get => _startMedication;
            set => Set(ref _startMedication, value);
        }
        private DateTime _finishMedication;
        public DateTime FinishMedicationTime
        {
            get => _finishMedication;
            set => Set(ref _finishMedication, value);
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
            get => _number;
            set => Set(ref _number, value);
        }
    }
}
