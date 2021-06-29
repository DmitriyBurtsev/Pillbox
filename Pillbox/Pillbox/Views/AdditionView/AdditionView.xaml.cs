using Pillbox.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pillbox.Views.AdditionView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdditionView : ContentPage
    {
        public AdditionView()
        {
            InitializeComponent();           
            BindingContext = new AdditionViewModel(Navigation);
            List<string> MedicineForms = new List<string>
            {"суппозитории", "инъекции", "таблетки","капсулы", "капли", "ампулы",
                "ингаляции", "доза спрея", "чайная ложка", "столовая ложка","свеча(и)",
                "пакетик", "вагинальные капсулы" , "вагинальные таблетки", "вагинальные препараты"};

            foreach (string formValue in MedicineForms)
            {
                formsPicker.Items.Add(formValue);
            }

            List<string> MedicineMethods = new List<string>        
            {"До приёма пищи", "После приёма пищи", "Во время приёма пищи"};

            foreach (string methodValue in MedicineMethods)
            {
                methodPicker.Items.Add(methodValue);
            }
            //startPicker.MinimumDate = DateTime.Now;
            //finishPicker.MinimumDate = startPicker.Date.AddDays(1);
            //Binding daysDurationBinding = new Binding { Source = daysStepper, Path = "Value" };
            //daysLabel.SetBinding(Label.TextProperty, daysDurationBinding);
            //daysLabel.Text = String.Format("Количество дней приёма: {0}", daysStepper.Value);
        }

        private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkBox.IsChecked==true)
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
            if(finishPicker.Date.DayOfYear > startPicker.Date.DayOfYear && finishPicker.Date.Year== startPicker.Date.Year)
            daysStepper.Value = Convert.ToDouble(finishPicker.Date.DayOfYear - startPicker.Date.DayOfYear);
            if (finishPicker.Date.DayOfYear < startPicker.Date.DayOfYear && finishPicker.Date.Year > startPicker.Date.Year)
                daysStepper.Value = Convert.ToDouble(finishPicker.Date.DayOfYear + 365 - startPicker.Date.DayOfYear);
            if(finishPicker.Date.DayOfYear > startPicker.Date.DayOfYear && finishPicker.Date.Year > startPicker.Date.Year) 
                checkBox.IsChecked = true;



        }
    }
}