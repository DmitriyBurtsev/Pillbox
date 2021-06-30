using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;

namespace Pillbox.Models
{
    [Table("Medicines")]
    public class Medicine
    {
       [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Title; // название препарата

        public string Format; // форма выпуска

        public string Method; // формат приема

        public Medication Medication; // массив приемов

        public Duration Duration; // длительность

        public Frequency Frequency; // частота

    }
}
