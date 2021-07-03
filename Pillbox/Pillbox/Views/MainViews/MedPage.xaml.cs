using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Pillbox.Database;
using Pillbox.Models;
using Pillbox.Services;
using Pillbox.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;
using System.Collections.ObjectModel;

namespace Pillbox.Views.MainViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedPage : ContentPage
    {
        //private IMedicineDatabase _connection;
        static object locker = new object();
        INotificationManager notificationManager;
        public MedPageViewModel ViewModelMP
        {
            get => BindingContext as MedPageViewModel;
            set => BindingContext = value;
        }
        public MedPage()
        {
            //_connection= new MedicineDatabase(DependencyService.Get<ISQLiteDb>());
            var medicineDB = new MedicineDatabase(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModelMP = new MedPageViewModel(pageService, medicineDB);
            InitializeComponent();
            notificationManager = DependencyService.Get<INotificationManager>();
            OnScheduleClick();
        }
        protected override void OnAppearing()
        {
           
            ViewModelMP.LoadMedicinesCommand.Execute(null);
            base.OnAppearing();
            
        }

        void OnMedicineSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModelMP.SelectMedicineCommand.Execute(e.SelectedItem);
        }


        void OnScheduleClick()
        {
            string title = $"Хозяин!";
            string message = $"Пора пить таблетку ххх";
            notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
        }




        //async void RefreshUsers()
        //{
        //    var userlist = await _connection.UpdateMedicineList();
        //    listView.ItemsSource = userlist;
        //}
        //private void listView_Refreshing(object sender, EventArgs e)
        //{
        //    RefreshUsers();
        //    listView.EndRefresh();
        //}
    }
}