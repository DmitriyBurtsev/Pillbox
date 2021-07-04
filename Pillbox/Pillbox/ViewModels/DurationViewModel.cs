using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.ViewModels
{
    public class DurationViewModel:BaseViewModel
    {
        public DurationViewModel(Duration duration)
        {
            Start = duration.Start;
            DurationDays = duration.DurationDays;
            Finish = duration.Finish;
        }
        private DateTime _start;
        public DateTime Start
        {
            get => _start;
            set => Set(ref _start, value);
        }
        private int _durationDays;
        public int DurationDays
        {
            get => _durationDays;
            set => Set(ref _durationDays, value);
        }
        private DateTime _finish;
        public DateTime Finish
        {
            get => _finish;
            set => Set(ref _finish, value);
        }
    }
}
