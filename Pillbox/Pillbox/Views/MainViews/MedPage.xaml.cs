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
        public MedPageViewModel ViewModelMP
        {
            get => BindingContext as MedPageViewModel;
            set => BindingContext = value;
        }
        public MedPage()
        {
            var medicineDB = new MedicineDatabase(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModelMP = new MedPageViewModel(pageService, medicineDB);
            InitializeComponent();            
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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}