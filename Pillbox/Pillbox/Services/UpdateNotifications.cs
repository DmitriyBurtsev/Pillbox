using Matcha.BackgroundService;
using Pillbox.Database;
using Pillbox.ViewModels;
using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pillbox.Services
{
    public class UpdateNotifications : IPeriodicTask
    {
        static object locker = new object();
       // MedPageViewModel mpvm;
        //IPageSevices ps;
        IMedicineDatabase db;
        //INotificationManager nm;
        INotificationDatabase nb;
        public UpdateNotifications(int seconds)
        {
            //ps = new PageService();
            db = new MedicineDatabase(DependencyService.Get<ISQLiteMedicineDb>());
            nb = new NotificationDatabase(DependencyService.Get<ISQLiteNotificationDb>());
            //mpvm = new MedPageViewModel();
            Interval = TimeSpan.FromSeconds(seconds);
           // nm = DependencyService.Get<INotificationManager>();

        }
        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        {            
            var meds = await db.UpdateMedicineList();
            var nots = await nb.UpdateNotificationList();
            foreach (var medicine in meds)
            {
                if ((medicine.Finish.Ticks + medicine.FinishMedicationTime.Ticks) < DateTime.Now.Ticks)
                  await db.DeleteMedicine(medicine);
                foreach (var notification in nots)
                {
                    if (medicine.Id != notification.Id)
                    {
                        await nb.DeleteNotification(notification);
                    }
                    notification.Id = medicine.Id;
                    notification.Message = $"Пора принять {medicine.Title} в количестве " +
                        $"{medicine.Dosage} {medicine.Format}";
                    notification.EveryDay = medicine.EveryDay;
                    notification.NonStop = medicine.NonStop;
                    notification.InDays = medicine.InDays;
                    DateTime timer = new DateTime(medicine.Start.Ticks + medicine.StartMedicationTime.Ticks);
                    int number = medicine.Number;
                    int indays = medicine.InDays;
                    if (number == 1)
                    {
                        if (medicine.NonStop == true && medicine.EveryDay == true)
                            notification.Timers.Add(timer);
                        if (medicine.NonStop == false && medicine.EveryDay == true)
                            notification.Timers.Add(timer);
                        if (medicine.NonStop == true && medicine.EveryDay == false)
                            notification.Timers.Add(timer);
                        if (medicine.NonStop == false && medicine.EveryDay == false)
                            notification.Timers.Add(timer);
                    }
                    if (number > 1)
                    {
                        number--;
                        var count = (medicine.FinishMedicationTime.Ticks - medicine.StartMedicationTime.Ticks) / number;
                        if (medicine.NonStop == true && medicine.EveryDay == true)
                        {
                            while (timer.Ticks <= timer.Ticks + medicine.FinishMedicationTime.Ticks)
                            {
                                notification.Timers.Add(timer);
                                timer = new DateTime(timer.Ticks + count);
                            }
                        }
                        if (medicine.NonStop == false && medicine.EveryDay == true)
                        {
                            DateTime finisher = new DateTime(medicine.Finish.Ticks + medicine.FinishMedicationTime.Ticks);
                            while (timer <= finisher)
                            {
                                notification.Timers.Add(timer);
                                timer = new DateTime(timer.Ticks + count);
                            }
                        }
                        if (medicine.NonStop==true && medicine.EveryDay==false)
                        {
                            DateTime finisher = new DateTime(timer.AddDays(indays).Ticks + medicine.FinishMedicationTime.Ticks);
                            DateTime tempTimer = timer;
                            int j = 0;
                            while (timer <= finisher)
                            {
                                for (int i = 0; i < indays; i++)
                                {
                                    while (timer.Ticks <= timer.Ticks + medicine.FinishMedicationTime.Ticks)
                                    {
                                        notification.Timers.Add(timer);
                                        timer = new DateTime(timer.Ticks + count);
                                    }
                                    timer = tempTimer.AddDays(j++);
                                }
                                j += indays;
                                timer = tempTimer.AddDays(j);
                            }
                        }
                        if (medicine.NonStop==false && medicine.EveryDay==false)
                        {
                            DateTime finisher = new DateTime(medicine.Finish.Ticks + medicine.FinishMedicationTime.Ticks);
                            DateTime tempTimer = timer;
                            int j=0;
                            while (timer <= finisher)
                            {
                                for (int i = 0; i < indays && timer <= finisher; i++)
                                {
                                    while (timer.Ticks <= timer.Ticks + medicine.FinishMedicationTime.Ticks)
                                    {
                                        notification.Timers.Add(timer);
                                        timer = new DateTime(timer.Ticks + count);
                                    }
                                    timer = tempTimer.AddDays(j++);
                                }
                                j+=indays;
                                timer = tempTimer.AddDays(j);
                            }
                        }
                    }
                    await nb.AddNotification(notification);
                }
            }
            return true;
        }
    }
}
