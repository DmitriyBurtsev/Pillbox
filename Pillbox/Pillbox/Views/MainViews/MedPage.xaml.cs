using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pillbox.Database;
using Pillbox.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pillbox.Views.MainViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedPage : ContentPage
    {
        public MedPage()
        {
            var medicineDB = new MedicineDatabase(App.dbpath);
            INavigation Navigation;            
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {           
            medicineList.ItemsSource = await App.Database.GetAllMedicinesAsync();
            this.BindingContext = new MedPageViewModel(Navigation);
            base.OnAppearing();
        }
    }
}