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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpConteoCatProductosList : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpConteoCatProductosList(object ficPaParameter)
        {
            InitializeComponent();


            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmConteoCatProductosList;

        }

        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item

            var FicViewModel = BindingContext as FicVmConteoCatProductosList;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);


        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmConteoCatProductosList;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}