using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pillbox.Models
{
    public class Medication
    {
        public DateTime StartMedicationTime { get; set; } // время первого приема

        public DateTime FinishMedicationTime { get; set; } // время последнего  приема

        public float Dosage { get; set; } // доза

        public int Number { get; set; }

    }
}
