using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            {
                this.BindingContext = new MedPageViewModel(Navigation);
            }
        }
    }
}