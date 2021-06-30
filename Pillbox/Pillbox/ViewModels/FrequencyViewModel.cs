using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.ViewModels
{
    public class FrequencyViewModel:BaseViewModel
    {
        public Frequency _frequency;
        public bool EveryDay
        {
            get => _frequency.EveryDay;
            set => Set(ref _frequency.EveryDay, value);
        }
        

        public int InDays
        {
            get => _frequency.InDays;
            set => Set(ref _frequency.InDays, value);
        }        
    }
}
