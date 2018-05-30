using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//--
using AppCocacolaNayMobiV2.Services.Inventarios;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpAlmacenList : ContentPage
    {
        private object FicParameter { get; set; }
        FicSrvCatAlmacenList FicService { get; }

        public FicViCpAlmacenList(object ficPaParameter)
        {
            InitializeComponent();

            FicParameter = ficPaParameter;

            FicService = new FicSrvCatAlmacenList();

            BindingContext = App.FicMetLocator.FicVmAlmacenList;
        }

        public async void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            string FicFiltro = FicSearchBar.Text;
            if (FicFiltro.Equals(""))
            {
                var grid = await FicService.FicMetGetListCatAlmacenes();
                dataGrid.ItemsSource = FicAgregarDatos(grid);
            }
            else
            {
                var grid = await FicService.FicMetGetListCatAlmacenes(FicFiltro);
                dataGrid.ItemsSource = FicAgregarDatos(grid);
            }
        }

        private ObservableCollection<zt_cat_almacenes> FicAgregarDatos(IList<zt_cat_almacenes> FicPaListZt_Cat_Almacenes)
        {
            ObservableCollection<zt_cat_almacenes> source = new ObservableCollection<zt_cat_almacenes>();
            foreach (var item in FicPaListZt_Cat_Almacenes)
            {
                source.Add(item);
            }
            return source;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmAlmacenList;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmAlmacenList;
            if (viewModel != null) viewModel.OnDisappearing();
        }

    }
    /*//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCpAlmacenList : ContentPage
	{
        private object FicParameter { get; set; }

        public FicViCpAlmacenList (object ficPaParameter)
		{
			InitializeComponent ();

            FicParameter = ficPaParameter;
            BindingContext = App.FicMetLocator.FicVmAlmacenList;
		}

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmAlmacenList;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmAlmacenList;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }*/
}