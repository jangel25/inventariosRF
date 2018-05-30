using System;
using System.Collections.Generic;
using System.Text;

namespace AppCocacolaNayMobiV2.Interfaces.Navigation
{
    public interface IFicSrvNavigationCatProductos
    {
        void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null);

        void FicMetNavigateTo(Type destinationType, object navigationContext = null);

        void FicMetNavigateBack();
    }
}
