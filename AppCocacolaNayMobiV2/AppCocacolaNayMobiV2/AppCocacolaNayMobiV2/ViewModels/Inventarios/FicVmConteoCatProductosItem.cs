using System;
using System.Collections.Generic;
using System.Text;
using AppCocacolaNayMobiV2.ViewModels.Base;
using System.Windows.Input;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmConteoCatProductosItem : FicViewModelBase
    {
        private zt_cat_productos Fic_Zt_Cat_Productos_Item;

        private ICommand FicSaveCommand;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationCatProductos FicLoSrvNavigationCatProductos;
        private IFicSrvCatProductos FicLoSrvCatProductos;

        public FicVmConteoCatProductosItem(
           IFicSrvNavigationCatProductos FicPaSrvNavigationCatProductos,
           IFicSrvCatProductos FicPaSrvCatProductos)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatProductos = FicPaSrvNavigationCatProductos;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatProductos = FicPaSrvCatProductos;
        }

        public zt_cat_productos Item
        {
            get { return Fic_Zt_Cat_Productos_Item; }
            set
            {
                Fic_Zt_Cat_Productos_Item = value;
                RaisePropertyChanged();
            }
        }

        public ICommand FicMetSaveCommand
        {
            get { return FicSaveCommand = FicSaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        public ICommand FicMetDeleteCommand
        {
            get { return FicDeleteCommand = FicDeleteCommand ?? new FicVmDelegateCommand(DeleteCommandExecute); }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        public override void OnAppearing(object FicPaNavigationContext)
        {
            var FicLoZt_inventarios = FicPaNavigationContext as zt_cat_productos;

            if (FicLoZt_inventarios != null)
            {
                Item = FicLoZt_inventarios;
            }

            base.OnAppearing(FicPaNavigationContext);
        }

        private async void SaveCommandExecute()
        {
            await FicLoSrvCatProductos.FicMetInsertNewCatProductos(Item);
            FicLoSrvNavigationCatProductos.FicMetNavigateBack();
        }

        private async void DeleteCommandExecute()
        {
            await FicLoSrvCatProductos.FicMetRemoveCatProductos(Item);
            FicLoSrvNavigationCatProductos.FicMetNavigateBack();
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationCatProductos.FicMetNavigateBack();
        }


    }
}
