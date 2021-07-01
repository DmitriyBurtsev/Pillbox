using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.Models
{
    public class Duration
    {
        public DateTime Start { get; set; } // день начала приема

        public int DurationDays { get; set; } // количество дней приема

        public DateTime Finish { get; set; } // дата последнего приема
    }
}
