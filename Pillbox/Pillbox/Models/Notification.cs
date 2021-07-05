using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;

namespace Pillbox.Models
{
    [Table("Notifications")]
    public class Notification
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Message { get; set; }
        public ObservableCollection<DateTime> Timers { get; set; }
    }
}
