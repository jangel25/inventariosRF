using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.ViewModels.Inventarios;
using AppCocacolaNayMobiV2.Views.Inventarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppCocacolaNayMobiV2.Services.Navigation
{
    public class FicSrvNavigationUnidadMedida : IFicSrvNavigationUnidadMedida
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(FicVmUnidadMedidaList),  typeof(FicViCpUnidadMedidaList) },
            { typeof(FicVmUnidadMedidaItem),   typeof(FicViCpUnidadMedidaItem) },
            { typeof(FicVmUnidadMedidaEditar), typeof(FicViUnidadMedidaEditar) },
            { typeof(FicVmUnidadMedidaEliminar), typeof(FicViUnidadMedidaEliminar) },
            { typeof(FicVmUnidadMedidaDetalle), typeof(FicViUnidadMedidaDetalle) }

        };

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public void FicMetNavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
            // Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
