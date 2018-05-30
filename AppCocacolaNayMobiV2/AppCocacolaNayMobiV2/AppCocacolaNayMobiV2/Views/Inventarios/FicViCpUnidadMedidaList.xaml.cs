using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCocacolaNayMobiV2.ViewModels.Inventarios;

//using XLabs.Forms.Controls;
using System;
using AppCocacolaNayMobiV2.Models.Inventarios;
using System.Collections.Generic;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using System.Linq;
//using Acr.UserDialogs;
using System.Collections.ObjectModel;
using AppCocacolaNayMobiV2.Services.Inventarios;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpUnidadMedidaList : ContentPage
    {
        private object FicParameter { get; set; }
        FicSrvUnidadMedidaList service { get; }

        public FicViCpUnidadMedidaList(object ficPaParameter)
        {
            InitializeComponent();

            FicParameter = ficPaParameter;
            BindingContext = App.FicMetLocator.FicVmUnidadMedidaList;

            service = new FicSrvUnidadMedidaList();
            FicListView.IsRefreshing = true;

        }

        public async void FicSearchButtonPressed(object sender, EventArgs e)
        {
            string filtro = FicSearchBar.Text;
            if (filtro.Equals(""))
            {
                var lista = await service.FicMetGetListUnidadMedida();
                FicListView.ItemsSource = FicAgregarDatos(lista);
                FicListView.IsRefreshing = true;
            }
            else
            {
                var lista = await service.FicMetGetListUnidadMedida2(filtro);
                FicListView.ItemsSource = FicAgregarDatos(lista);
                FicListView.IsRefreshing = true;
            }
        }


        private ObservableCollection<zt_cat_unidad_medidas> FicAgregarDatos(IList<zt_cat_unidad_medidas> FicPaListZt_UnidadMedida)
        {
            ObservableCollection<zt_cat_unidad_medidas> source = new ObservableCollection<zt_cat_unidad_medidas>();
            foreach (var item in FicPaListZt_UnidadMedida)
            {
                source.Add(item);
            }
            return source;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmUnidadMedidaList;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmUnidadMedidaList;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}