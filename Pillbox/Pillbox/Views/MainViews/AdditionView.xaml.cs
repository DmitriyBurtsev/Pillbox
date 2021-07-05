using Pillbox.Database;
using Pillbox.Services;
using Pillbox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pillbox.Views.MainViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdditionView : ContentPage
    {
        public readonly IPageSevices _pageservice;
        public AdditionView(MedicineViewModel viewModel)
        {
            InitializeComponent();

            var medicineDatabase = new MedicineDatabase(DependencyService.Get<ISQLiteMedicineDb>());
            _pageservice = new PageService();
            var pageService = new PageService();
            Title = (viewModel.Title == null) ? "Добавление лекарства" : $"{Title}";
            BindingContext = new AdditionViewModel(viewModel ?? new MedicineViewModel(), medicineDatabase, pageService);




            List<string> MedicineForms = new List<string>
            {"суппозитории(я)", "инъекция(и)", "таблетка(и)","капсула(ы)", "капля(и)", "ампула(ы)",
                "ингаляция(и)", "доза(ы) спрея", "чайная(ые) ложка(и)", "столовая(ые) ложка(и)","свеча(и)",
                "пакетик(а)"};

            foreach (string formValue in MedicineForms)
            {
                formsPicker.Items.Add(formValue);
            }

            List<string> MedicineMethods = new List<string>
            {"До приёма пищи", "После приёма пищи", "Во время приёма пищи", "Не имеет значения"};

            foreach (string methodValue in MedicineMethods)
            {
                methodPicker.Items.Add(methodValue);
            }

            for (int i = 2; i < 100; i++)
            {
                daysPicker.Items.Add(Convert.ToString(i));
            }

            for (double i = 0.5; i < 10; i += 0.5)
            {
                dosagePicker.Items.Add(Convert.ToString(i));
            }

            for (int i = 1; i < 10; i++)
            {
                numberPicker.Items.Add(Convert.ToString(i));
            }
            //while ()
            // saveButton.IsEnabled = false;
            //Binding daysDurationBinding = new Binding { Source = daysStepper, Path = "Value" };
            //daysLabel.SetBinding(Label.TextProperty, daysDurationBinding);
        }

        private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                finishLabel.IsVisible = false;
                finishPicker.IsVisible = false;
                daysLabel.IsVisible = false;
                daysStepper.IsVisible = false;
            }
            else
            {
                finishLabel.IsVisible = true;
                finishPicker.IsVisible = true;
                daysLabel.IsVisible = true;
                daysStepper.IsVisible = true;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            startPicker.MinimumDate = DateTime.Today;
            finishPicker.MinimumDate = startPicker.Date.AddDays(1);
            daysPicker.IsVisible = false;
            daysLbl.IsVisible = false;
            startTime.Time = new TimeSpan(08, 00, 00);
            finishTime.Time = new TimeSpan(20, 00, 00);
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        protected override void OnDisappearing()
        {
            
            base.OnDisappearing();
        }

        private void startPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            startPicker.MinimumDate = DateTime.Today;
            finishPicker.MinimumDate = startPicker.Date.AddDays(1);
        }

        private void daysStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            finishPicker.Date = startPicker.Date.AddDays(daysStepper.Value);
        }

        private void finishPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (finishPicker.Date.DayOfYear > startPicker.Date.DayOfYear && finishPicker.Date.Year == startPicker.Date.Year)
                daysStepper.Value = Convert.ToDouble(finishPicker.Date.DayOfYear - startPicker.Date.DayOfYear);
            if (finishPicker.Date.DayOfYear < startPicker.Date.DayOfYear && finishPicker.Date.Year > startPicker.Date.Year)
                daysStepper.Value = Convert.ToDouble(finishPicker.Date.DayOfYear + 365 - startPicker.Date.DayOfYear);
            if (finishPicker.Date.DayOfYear > startPicker.Date.DayOfYear && finishPicker.Date.Year > startPicker.Date.Year)
                checkBox.IsChecked = true;



        }

        private void freqEveryday_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (freqEveryday.IsChecked == true)
            {
                freqIndays.IsVisible = false;
                freqIndLbl.IsVisible = false;               
            }
            else
            {
                freqIndays.IsVisible = true;
                freqIndLbl.IsVisible = true;               
            }
        }

        private void freqIndays_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (freqIndays.IsChecked == true)
            {
                freqEveryday.IsVisible = false;
                freqEvrLbl.IsVisible = false;               
                daysPicker.IsVisible = true;
                daysLbl.IsVisible = true;

            }
            else
            {
                freqEveryday.IsVisible = true;
                freqEvrLbl.IsVisible = true;               
                daysPicker.IsVisible = false;
                daysLbl.IsVisible = false;
            }
        }

        private void daysPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            daysPicker.IsVisible = false;
            daysLbl.IsVisible = false;

        }

        private void daysPicker_Unfocused(object sender, FocusEventArgs e)
        {
            daysPicker.IsVisible = false;
            daysLbl.IsVisible = false;
        }        
    }
}