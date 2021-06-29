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
            Dictionary<string, string> MedicineForms = new Dictionary<string, string>
        {
            {"суппозитории", "суппозитории" }, {"инъекции", "инъекции" },
            {"таблетки", "таблетки" }, {"МЕ", "МЕ" },
            {"капсулы", "капсулы" }, {"капли", "капли" },
            {"ампулы", "ампулы" }, {"граммы", "граммы" },
            {"единицы", "единицы" }, {"ингаляции", "ингаляции" },
            {"доза спрея", "доза спрея" }, {"использование", "использование" },
            {"миллиграмм(ы)", "миллиграмм(ы)" }, {"миллилитр(ы)", "миллилитр(ы)" },
            {"штуки", "штуки" }, {"чайная ложка", "чайная ложка" },
            {"столовая ложка", "столовая ложка" }, {"свеча(и)", "свеча(и)" },
            {"пластырь", "пластырь" }, {"пакетик", "пакетик" },
            {"вагинальные капсулы", "вагинальные капсулы" },
            {"вагинальные таблетки", "вагинальные таблетки" },
            {"вагинальные препараты", "вагинальные препараты" },
        };
            foreach (string formValue in MedicineForms.Keys)
            {
                formsPicker.Items.Add(formValue);
            }
            Dictionary<string, string> MedicineMethods = new Dictionary<string, string>
        {
            {"До приёма пищи", "До приёма пищи" }, {"После приёма пищи", "После приёма пищи" },
            {"Во время приёма пищи", "Во время приёма пищи" },            
        };
            foreach (string methodValue in MedicineMethods.Keys)
            {
                methodPicker.Items.Add(methodValue);
            }
        }
    }
}