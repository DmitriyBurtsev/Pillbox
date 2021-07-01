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
        
        public MedicationViewModel Medication { get; set; } // массив приемов
        
        
        public DurationViewModel Duration { get; set; } // длительность
        
        public FrequencyViewModel Frequency { get; set; } // частота

    }
}
