using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpConteoCatProductosItem : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpConteoCatProductosItem(object ficPaParameter)
        {
            InitializeComponent();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmConteoCatProductosItem;

            var layout = stack;
            var scroll = new ScrollView { Content = layout };
            Content = scroll;

        }

        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmConteoCatProductosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmConteoCatProductosItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}