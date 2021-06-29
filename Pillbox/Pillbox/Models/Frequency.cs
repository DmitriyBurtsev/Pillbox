using System;
using System.Collections.Generic;
using System.Text;

namespace Pillbox.Models
{
    public class Frequency
    {
        public int DailyTimes; // сколько раз в день

        public int DailyHours; // через сколько часов

        public int InDays; // через сколько дней
        public enum DaysOfWeek { }; // определенные дни недели

        public int CircleDuration; // цикл приема

        public int MedicationDays; // количесвто дней приема в цикле

        public int BreakDays; // дни перерыва
    }
}
