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
    public partial class FicViCpUnidadMedidaItem : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpUnidadMedidaItem(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;
            BindingContext = App.FicMetLocator.FicVmUnidadMedidaItem;
        }

        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmUnidadMedidaItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
            DateTime fecha = DateTime.Now;
            txtID.IsEnabled = false;
            txtfRegistro.Text = fecha.ToString("MM/dd/yyyy");
            txtUsuarioreg.Text = "PEGASO";
            txtUsuarioreg.IsEnabled = false;
            txtfRegistro.IsEnabled = false;
            Activo.IsVisible = false;
            Borrado.IsVisible = false;
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmUnidadMedidaItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }

        private void OnToogleSwitch01(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                Activo.Text = "S";
            }
            if (value == false)
            {
                Activo.Text = "N";
            }

        }
        private void OnToogleSwitch02(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                Borrado.Text = "S";
            }
            if (value == false)
            {
                Borrado.Text = "N";
            }

        }
    }
}