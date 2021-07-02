using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Pillbox.ViewModels;
using SQLite;

namespace Pillbox.Models
{
    [Table("Medicines")]
    public class Medicine
    {
       [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string Title { get; set; } // название препарата
        
        public string Format { get; set; } // форма выпуска
        
        public string Method { get; set; } // формат приема

        public DateTime StartMedicationTime { get; set; } // время первого приема

        public DateTime FinishMedicationTime { get; set; } // время последнего  приема

        public float Dosage { get; set; } // доза

        public int Number { get; set; } // количество приемов в день

        public DateTime Start { get; set; } // день начала приема

        public int DurationDays { get; set; } // количество дней приема

        public DateTime Finish { get; set; } // дата последнего приема        
        public bool EveryDay { get; set; } // флаг: ежедневно

        public int InDays { get; set; } // через сколько дней

        public bool NonStop { get; set; } // без даты окончания
    }
}
