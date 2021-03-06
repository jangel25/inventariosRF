﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;

namespace AppCocacolaNayMobiV2.Views.Inventarios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViAlmacenDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public FicViAlmacenDetalle (object ficPaParameter)
		{
			InitializeComponent ();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmAlmacenDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmAlmacenDetalle;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}