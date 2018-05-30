using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpAlmacenItem : ContentPage
    {

        private object FicLoParameter { get; set; }

        public FicViCpAlmacenItem(object ficPaParameter)
        {
            InitializeComponent();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmAlmacenItem;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }

        private void Switch_OnToggledActivo(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;
            if (isToggled == true)
            {
                FicLblActivo.Text = "S";
            }
            else
            {
                FicLblActivo.Text = "N";
            }
        }
        private void Switch_OnToggledBorrado(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;
            if (isToggled == true)
            {
                FicLblBorrado.Text = "S";
            }
            else
            {
                FicLblBorrado.Text = "N";
            }
        }
    }
    /*[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCpAlmacenItem : ContentPage
	{

        private object FicLoParameter { get; set; }

		public FicViCpAlmacenItem (object ficPaParameter)
		{
			InitializeComponent ();


            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmAlmacenItem;
		}

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }*/
}