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
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(int selectedMedicineId)
        {
            InitializeComponent();
            BindingContext = new DetailsPageViewModel(Navigation, selectedMedicineId);
        }
    }
}