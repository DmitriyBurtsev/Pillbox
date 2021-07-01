using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.ViewModels
{
    public class FrequencyViewModel:BaseViewModel
    {
        public FrequencyViewModel(Frequency frequency)
        {
            EveryDay = frequency.EveryDay;
            InDays = frequency.InDays;
        }
        private bool _everyDay;
        public bool EveryDay
        {
            get => _everyDay;
            set => Set(ref _everyDay, value);
        }
        private int _inDays;
        public int InDays
        {
            get => _inDays;
            set => Set(ref _inDays, value);
        }        
    }
}
