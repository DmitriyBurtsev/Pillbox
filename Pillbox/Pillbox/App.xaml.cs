using Pillbox.Database;
using Pillbox.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
