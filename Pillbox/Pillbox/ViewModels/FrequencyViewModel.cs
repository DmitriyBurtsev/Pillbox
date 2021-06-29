using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.ViewModels
{
    public class FrequencyViewModel:BaseViewModel
    {
        public Frequency _frequency;
        public int DailyTimes
        {
            get => _frequency.DailyTimes;
            set => Set(ref _frequency.DailyTimes, value);
        }

        public int DailyHours
        {
            get => _frequency.DailyHours;
            set => Set(ref _frequency.DailyHours, value);
        }

        public int InDays
        {
            get => _frequency.InDays;
            set => Set(ref _frequency.InDays, value);
        }        
    }
}
