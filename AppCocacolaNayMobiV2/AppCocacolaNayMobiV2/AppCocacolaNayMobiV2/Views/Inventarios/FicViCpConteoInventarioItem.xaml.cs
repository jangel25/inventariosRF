using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;
using System;
using System.Threading.Tasks;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpConteoInventarioItem : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpConteoInventarioItem(object ficPaParameter)
        {
            InitializeComponent();

            var fecha = DateTime.Now;
            entryFecUltModidicacion.Text = fecha.Month + "-" + fecha.Day + "-" + fecha.Year;
            usuModifico.Text = "EB2";

            FicLoParameter = ficPaParameter;
            if (FicLoParameter == null)
            {
                DisplayAlert("Advertencia", "Debe seleccionar un registro", "OK");
                return;
            }
            BindingContext = App.FicMetLocator.FicVmConteoInventarioItem;

            WaitAndExecute(1000);




        }

        protected override void OnAppearing()
        {
           
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmConteoInventarioItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);

            



        }

        protected async Task WaitAndExecute(int milisec)
        {
            await Task.Delay(milisec);

            inicioSwitch(entryBorrado,borrado);
            inicioSwitch(entryActivo,activo);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmConteoInventarioItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
            

        }
        
        private void Switch_OnToggledActivo(object sender,ToggledEventArgs e)
        {
            bool isToggled = e.Value;
            if (isToggled)
            {
                entryActivo.Text = "S";
            }
            else
            {
                entryActivo.Text = "N";
            }
        }
        
        
        private void Switch_OnToggledBorrado(object sender,ToggledEventArgs e)
        {
            bool isToggled = e.Value;
            if (isToggled)
            {
                entryBorrado.Text = "S";
            }
            else
            {
                entryBorrado.Text = "N";
            }
        }

        public void inicioSwitch(Entry e,Switch s)
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

       





    }
}