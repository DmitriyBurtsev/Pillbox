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
            {"суппозитории", "инъекции", "таблетки","ка псулы", "капли", "ампулы",
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

            //Binding daysDurationBinding = new Binding { Source = daysStepper, Path = "Value" };
            //daysLabel.SetBinding(Label.TextProperty, daysDurationBinding);




            //daysLabel.Text = String.Format("Количество дней приёма: {0}", daysStepper.Value);
        }
    }
}