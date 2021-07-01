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
        public const string DbFileName = "medicines.db";

        public static string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbFileName);

        public static MedicineDatabase database;
        public static MedicineDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MedicineDatabase(dbpath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();            
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            await Database.CreateTable();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
