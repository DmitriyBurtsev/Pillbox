using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pillbox.Models
{
    public class Medication
    {
        public DateTime StartMedicationTime; // время первого приема

        public DateTime FinishMedicationTime; // время последнего  приема

        public float Dosage; // доза

        public int Number;

    }
}
