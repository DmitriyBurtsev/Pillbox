using Matcha.BackgroundService;
using Pillbox.Database;
using Pillbox.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pillbox.Services
{
    public class PeriodicCall : IPeriodicTask
    {
        MedPageViewModel mpvm;
        //IPageSevices ps;
        IMedicineDatabase db;
        INotificationManager nm;
        INotificationDatabase nb;
        public PeriodicCall(int seconds)
        {
            //ps = new PageService();
            db = new MedicineDatabase(DependencyService.Get<ISQLiteMedicineDb>());
            nb = new NotificationDatabase(DependencyService.Get<ISQLiteNotificationDb>());
            mpvm = new MedPageViewModel();
            Interval = TimeSpan.FromSeconds(seconds);
            nm = DependencyService.Get<INotificationManager>();

        }
        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        {            
            var meds = await db.UpdateMedicineList();
            foreach (var medicine in meds)
            {
                try
                {
                    //TimeSpan stMed = medicine.StartMedicationTime;
                    //DateTime _stMed = new DateTime(stMed.Ticks);
                    DateTime tempTimer;
                    DateTime timer = new DateTime(medicine.Start.Ticks + medicine.StartMedicationTime.Ticks);                   
                    int x = medicine.Number;
                    if (x==1)
                    {
                        nm.SendNotification("Напоминаю", $"Пора принять {medicine.Title} " +
                               $"в количестве {medicine.Dosage} {medicine.Format}", timer);
                    }
                    else if (x > 1)
                    {
                        x--;
                        var count = (medicine.FinishMedicationTime.Ticks - medicine.StartMedicationTime.Ticks) / x;
                        if (medicine.NonStop == true)
                        {
                            if (timer >= DateTime.Now)
                            {
                                nm.SendNotification("Напоминаю", $"Пора принять {medicine.Title} " +
                                    $"в количестве {medicine.Dosage} {medicine.Format}", timer);
                                timer = new DateTime(timer.Ticks + count);
                                tempTimer = timer;
                            }
                        }
                        if (medicine.NonStop == false)
                        {
                            DateTime finishTimer = new DateTime(medicine.Finish.Ticks + medicine.FinishMedicationTime.Ticks);
                            if (timer <= finishTimer && timer >= DateTime.Now)
                            {
                                nm.SendNotification("Напоминаю", $"Пора принять {medicine.Title} " +
                                   $"в количестве {medicine.Dosage} {medicine.Format}", timer);
                                timer = new DateTime(timer.Ticks + count);
                                tempTimer = timer;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception:" + e);
                }
            }
            // mpvm.TaskTime();
            return true;
        }
    }
}
