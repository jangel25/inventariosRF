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
    public partial class FicViUnidadMedidaEliminar : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViUnidadMedidaEliminar(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;
            BindingContext = App.FicMetLocator.FicVmUnidadMedidaEliminar;

        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmUnidadMedidaEliminar;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmUnidadMedidaEliminar;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}