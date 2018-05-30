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
    public partial class FicViUnidadMedidaEditar : ContentPage
    {
        private object FicLoParameter { get; set; }
        public FicViUnidadMedidaEditar(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;
            BindingContext = App.FicMetLocator.FicVmUnidadMedidaEditar;
        }
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmUnidadMedidaEditar;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
            DateTime fecha = DateTime.Now;

            txtUsuarioreg.Text = "PEGASO";
            txtUsuariomod.Text = "PEGASO";
            txtfModifico.Text = fecha.ToString("MM/dd/yyyy");
            txtUsuarioreg.IsEnabled = false;
            txtUsuariomod.IsEnabled = false;
            txtfRegistro.IsEnabled = false;
            txtfModifico.IsEnabled = false;
            txtID.IsEnabled = false;
            txtActivo.IsVisible = false;
            txtBorrado.IsVisible = false;
            WaitAndExecute(500);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmUnidadMedidaEditar;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }

        private void OnToogleSwitch01(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {
                txtActivo.Text = "S";

            }
            if (value == false)
            {

                txtActivo.Text = "N";
            }

        }

        private void OnToogleSwitch02(object sender, ToggledEventArgs e)
        {
            var value = e.Value;
            if (value == true)
            {

                txtBorrado.Text = "S";

            }
            if (value == false)
            {
                txtBorrado.Text = "N";
            }

        }

        public void SwitchIni(Entry e, Switch s)
        {
            if (e.Text.Equals("S"))
            {
                s.IsToggled = true;
            }
            else
            {
                s.IsToggled = false;
            }
        }

        protected async Task WaitAndExecute(int time)
        {
            await Task.Delay(time);

            SwitchIni(txtActivo, SwitchAct);
            SwitchIni(txtBorrado, SwitchBor);
        }
    }
}