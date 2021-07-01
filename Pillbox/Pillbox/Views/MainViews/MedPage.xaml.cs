using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pillbox.Database;
using Pillbox.Services;
using Pillbox.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pillbox.Views.MainViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedPage : ContentPage
    {
        public MedPageViewModel MedPageVM
        {
            get => BindingContext as MedPageViewModel;
            set => BindingContext = value;
        }

        public MedPage()
        {
            var medicineDB = new MedicineDatabase(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            MedPageVM = new MedPageViewModel(pageService, medicineDB);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MedPageVM.LoadMedicinesCommand.Execute(null);
            base.OnAppearing();
        }
        void OnMedicineSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MedPageVM.SelectMedicineCommand.Execute(e.SelectedItem);
        }
    }
}