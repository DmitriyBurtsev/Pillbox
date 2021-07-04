using Android.Content;
using Android.OS;
using Pillbox.Database;
using Pillbox.Services;
using Pillbox.ViewModels;
using Xamarin.Forms;

namespace BackgroundTasks.Droid
{
    [BroadcastReceiver]
    public class BackgroundReceiver : BroadcastReceiver
    {
        public MedPageViewModel vm;
        public IPageSevices ps;
        public IMedicineDatabase db;
        public override void OnReceive(Context context, Intent intent)
        {
            ps = new PageService();
            db = new MedicineDatabase(DependencyService.Get<ISQLiteDb>());
            vm = new MedPageViewModel(ps,db);
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();

            vm.TaskTime();

            wakeLock.Release();
        }
    }
}