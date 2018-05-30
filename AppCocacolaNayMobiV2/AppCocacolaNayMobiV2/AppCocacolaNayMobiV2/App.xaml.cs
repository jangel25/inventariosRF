﻿using AppCocacolaNayMobiV2.ViewModels.Base;
using AppCocacolaNayMobiV2.Views.REST;
using AppCocacolaNayMobiV2.Views.Inventarios;
//using AppCocacolaNayMobiV2.Views.Menu;
using Xamarin.Forms;

namespace AppCocacolaNayMobiV2
{
    public partial class App : Application
    {

        private static FicViewModelLocator ficVmLocator;
        //FIC: Metodo
        public static FicViewModelLocator FicMetLocator
        {
            get { return ficVmLocator = ficVmLocator ?? new FicViewModelLocator(); }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            //MainPage = new Views.Menu.FicMDP1();
            MainPage = new NavigationPage(new FicViCpConteoInventarioList(null));
            //MainPage = new NavigationPage(new FicViConteoDetInventarioList(null));
            //MainPage = new NavigationPage(new FicViCpAlmacenList(null));
            //MainPage = new NavigationPage(new FicViCpConteoCatProductosList(null));
            //MainPage = new NavigationPage(new FicViCpUnidadMedidaList(null));
            //MainPage = new NavigationPage(new ImportExportxaml());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
