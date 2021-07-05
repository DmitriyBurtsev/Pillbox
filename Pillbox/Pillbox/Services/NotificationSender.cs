using Matcha.BackgroundService;
using Pillbox.Database;
using Pillbox.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pillbox.Services
{
    public class NotificationSender : IPeriodicTask
    {
        //IPageSevices ps;
       // IMedicineDatabase db;
        INotificationManager _notification;
        INotificationDatabase nb;
        public NotificationSender(int seconds)
        {
            //ps = new PageService();
           // db = new MedicineDatabase(DependencyService.Get<ISQLiteMedicineDb>());
            nb = new NotificationDatabase(DependencyService.Get<ISQLiteNotificationDb>());
           // mpvm = new MedPageViewModel();
            Interval = TimeSpan.FromSeconds(seconds);
            _notification = DependencyService.Get<INotificationManager>();

        }
        public TimeSpan Interval { get; set; }
        public async Task<bool> StartJob()
        {
            var nots = await nb.UpdateNotificationList();
            foreach (var notification in nots)
            {
                foreach (var timer in notification.Timers)
                {
                    bool _isSend = false;                   
                    if (timer >= DateTime.Now && timer <= DateTime.Now.AddMinutes(1))
                    {
                        _notification.SendNotification("Внимание", notification.Message, timer);
                        _isSend = true;
                        if (_isSend == true)
                        {
                            if (notification.EveryDay == true && notification.NonStop == true && _isSend)
                                timer.AddDays(1);
                            if (notification.EveryDay == false && notification.NonStop == true && _isSend)
                                timer.AddDays(notification.InDays);

                            notification.Timers.Remove(timer);
                        }
                    }
                    if (timer < DateTime.Now.AddMinutes(1))
                        notification.Timers.Remove(timer);
                }

            }
            return true;
        }
    }
}
