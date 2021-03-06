﻿using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Services.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViConteoDetInventarioItem : ContentPage
    {
        ZXingScannerPage scanPage;
        public String texto;
        //variable lista del tipo zt_cat_almacenes almacenara los registros
        List<zt_cat_almacenes> almacenes;
        //objeto de la clase que contiene la funcion para traer la lista de la tabla
        FicSrvCatAlmacenList ficSrvCatAlmacenList;
        private object FicLoParameter { get; set; }

        private float cantidadPZA;

        public FicViConteoDetInventarioItem(object ficPaParameter)
        {
            InitializeComponent();

            btnBarras.Clicked += ButtonScanDefault_Clicked;
            txtIdInventario.IsEnabled = false;
            txtIdConteo.IsEnabled = false;
            txtCEDI.IsEnabled = false;
            txtMaterial.IsEnabled = false;
            txtCantidadPZA.IsEnabled = false;

            txtNumerico.ValueChanged += (sender, e) => {
                unidadMedidaSeleccionada();
            };

            txtBuscarCodBarras.SearchButtonPressed += (sender, e) => {
                buscarCodBarras();
            };

            pickerUM.SelectedIndexChanged += (sender, args) =>
            {
                unidadMedidaSeleccionada();
            };

            txtBuscarSKU.SearchButtonPressed += (sender, e) => {
                buscarSKU();
            };

            btnGuardar.Clicked += (sender, e) => {
                btnGuardar_clicked();
            };
            var fecha = DateTime.Now;
            lblFecha.Text = fecha.ToString("dd-MM-yyyy");
            lblHora.Text = fecha.ToString("HH:mm");
            lblUsuario.Text = "Equipo DAM-2";

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.Zt_InvConteosItemVM;

            pickerAlmacen.SelectedIndex = 0;
        }//Fin constructor

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmConteoDetInventarioItem;
            ficSrvCatAlmacenList = new FicSrvCatAlmacenList();
            //almaceno en la variable creada el resultado de la funcion para obt. la lista
            almacenes = ficSrvCatAlmacenList.GetAll_zt_cat_almacenes();
            //recorro la lista de almacenes
            foreach (zt_cat_almacenes almacen in almacenes)
            {
                //agregar cada elemento de la lista al picker
                pickerAlmacen.Items.Add(almacen.Almacen);
            }

                if (viewModel != null) viewModel.OnAppearing(FicLoParameter);

            txtIdConteo.Text = viewModel.Zt_inventario_conteos.IdConteo.ToString();
        }//Fin OnAppearing

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmConteoDetInventarioItem;
            if (viewModel != null) viewModel.OnDisappearing();
        }

        private async void ButtonScanDefault_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopModalAsync();
                    DisplayAlert("Código Escaneado", result.Text, "OK");
                    texto = result.Text;
                    txtBuscarCodBarras.Text = texto;
                });
                ;
            };

            await Navigation.PushModalAsync(scanPage);
            buscarCodBarras();
        }

        private async void buscarCodBarras()
        {
            var viewModel = BindingContext as FicVmConteoDetInventarioItem;
            if (viewModel.FindProductoCodBarrasExecute(txtBuscarCodBarras.Text))
            {
                txtBuscarCodBarras.Text = viewModel._selected_zt_cat_productos.CodigoBarras;
                txtBuscarSKU.Text = viewModel._selected_zt_cat_productos.SKU;
                txtMaterial.Text = viewModel._selected_zt_cat_productos.Material;
            }
            else { await DisplayAlert("Aviso", "Este código de barras no existe", "OK"); }
        }

        private async void buscarSKU()
        {
            var viewModel = BindingContext as FicVmConteoDetInventarioItem;
            if (viewModel.FindProductoSKUExecute(txtBuscarSKU.Text))
            {
                txtBuscarCodBarras.Text = viewModel._selected_zt_cat_productos.CodigoBarras;
                txtBuscarSKU.Text = viewModel._selected_zt_cat_productos.SKU;
                txtMaterial.Text = viewModel._selected_zt_cat_productos.Material; 
            }
            else { await DisplayAlert("Aviso", "El SKU no existe", "OK"); }
        }

        private void unidadMedidaSeleccionada()
        {
            var viewModel = BindingContext as FicVmConteoDetInventarioItem;
            if (pickerUM.SelectedItem != null)
            {
                var selectedItem = (zt_cat_unidad_medidas) pickerUM.SelectedItem;
                viewModel.Zt_inventario_conteos.IdUMedida = selectedItem.IdUMedida;
               
                txtCantidadPZA.Text = "" + viewModel.Zt_inventario_conteos.CantFisica * selectedItem.CantidadPZA;
            }
            else { pickerUM.SelectedItem = viewModel.SelectedZt_cat_unidad_medidas; }
        }

        private void calcularCantidadPZA() {
            var viewModel = BindingContext as FicVmConteoDetInventarioItem;
            var selectedItem = (zt_cat_unidad_medidas)pickerUM.SelectedItem;
            viewModel.Zt_inventario_conteos.IdUMedida = selectedItem.IdUMedida;
            cantidadPZA = viewModel.Zt_inventario_conteos.CantFisica * selectedItem.CantidadPZA;
            txtCantidadPZA.Text = "" + cantidadPZA;
        }

        private async void btnGuardar_clicked() {
            var viewModel = BindingContext as FicVmConteoDetInventarioItem;
            if (viewModel.FindProductoSKUExecute(txtBuscarSKU.Text) &&
                viewModel.FindProductoCodBarrasExecute(txtBuscarCodBarras.Text))
            {
                viewModel.SaveCommandExecute(); 
            }
            else { await DisplayAlert("Aviso", "No se puede hacer un conteo a un producto no registrado, verifique SKU o Codigo de barras", "OK"); }
        }
    }
}