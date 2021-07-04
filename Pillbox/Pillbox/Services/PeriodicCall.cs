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
    public class PeriodicCall : IPeriodicTask
    {
        MedPageViewModel mpvm;
        IPageSevices ps;
        IMedicineDatabase db;
        public PeriodicCall(int seconds)
        {
            ps = new PageService();
            db = new MedicineDatabase(DependencyService.Get<ISQLiteDb>());
            mpvm = new MedPageViewModel(ps, db);
            Interval = TimeSpan.FromSeconds(seconds);

        }
        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        {
            mpvm.TaskTime();
            return true;
        }
    }
}
