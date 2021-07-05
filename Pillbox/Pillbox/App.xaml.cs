using Pillbox.Database;
using Pillbox.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Matcha.BackgroundService;
using Pillbox.Services;

namespace Pillbox
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();            
            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
           BackgroundAggregatorService.Add(() => new UpdateNotifications(60));
           BackgroundAggregatorService.Add(() => new NotificationSender(60));
           BackgroundAggregatorService.StartBackgroundService();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
