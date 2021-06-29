using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.ViewModels
{
    public class DurationViewModel:BaseViewModel
    {
        public Duration _duration;
        public DateTime Start
        {
            get => _duration.Start;
            set => Set(ref _duration.Start, value);
        }
        public int DurationDays
        {
            get => _duration.DurationDays;
            set => Set(ref _duration.DurationDays, value);
        }
        public DateTime Finish
        {
            get => _duration.Finish;
            set => Set(ref _duration.Finish, value);
        }
    }
}
