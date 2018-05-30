using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;
using System.Threading.Tasks;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViAlmacenEditar : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViAlmacenEditar(object ficPaParameter)
        {
            InitializeComponent();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmAlmacenEditar;

            WaitAndExecute(500);
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenEditar;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenEditar;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }

        private void Switch_OnToggledActivo(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;
            if (isToggled == true)
            {
                FicActivo.Text = "S";
            }
            else
            {
                FicActivo.Text = "N";
            }
        }

        private void Switch_OnToggledBorrado(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;
            if (isToggled == true)
            {
                FicBorrado.Text = "S";
            }
            else
            {
                FicBorrado.Text = "N";
            }
        }

        public void inicioSwitch(Entry e, Switch s)
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

            inicioSwitch(FicActivo, ficSwitchActivo);
            inicioSwitch(FicBorrado, ficSwitchBorrado);
        }
    }
    /*[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAlmacenEditar : ContentPage
	{
        private object FicLoParameter { get; set; }

		public FicViAlmacenEditar (object ficPaParameter)
		{
			InitializeComponent ();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmAlmacenEditar;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenEditar;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenEditar;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }*/
}