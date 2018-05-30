using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Base;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System;
using Xamarin.Forms;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmAlmacenItem : FicViewModelBase
    {
        private zt_cat_almacenes Fic_Zt_Cat_Almacenes_Item;
        private ObservableCollection<zt_cat_cedis> Fic_Items_CEDIS;
        public zt_cat_cedis Fic_Item_CEDI;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationInventario FicLoSrvNavigationInventario;
        private IFicSrvCatAlmacen FicLoSrvCatAlmacenes;

        public FicVmAlmacenItem(
            IFicSrvNavigationInventario FicPaSrvNavigationInventario,
            IFicSrvCatAlmacen FicPaSrvCatAlmacen)
        {
            FicLoSrvNavigationInventario = FicPaSrvNavigationInventario;
            FicLoSrvCatAlmacenes = FicPaSrvCatAlmacen;
        }

        public zt_cat_almacenes Item
        {
            get { return Fic_Zt_Cat_Almacenes_Item; }
            set
            {
                Fic_Zt_Cat_Almacenes_Item = value;
                Fic_Zt_Cat_Almacenes_Item.FechaReg = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                Fic_Zt_Cat_Almacenes_Item.Activo = "N";
                Fic_Zt_Cat_Almacenes_Item.Borrado = "N";
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<zt_cat_cedis> FicMetItemsCEDIS
        {
            get { return Fic_Items_CEDIS; }
            set
            {
                Fic_Items_CEDIS = value;
                RaisePropertyChanged();
            }
        }

        public zt_cat_cedis SelectedCEDI
        {
            get { return Fic_Item_CEDI; }
            set
            {
                Fic_Item_CEDI = value;
                RaisePropertyChanged();
            }
        }

        public ICommand FicMetSaveCommand
        {
            get { return FicSaveCommand = FicSaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            var FicLoZt_cat_almacenes = FicPaNavigationContext as zt_cat_almacenes;

            if (FicLoZt_cat_almacenes != null)
            {
                Item = FicLoZt_cat_almacenes;
            }

            var result = await FicLoSrvCatAlmacenes.FicMetGetListCEDIS();

            FicMetItemsCEDIS = new ObservableCollection<zt_cat_cedis>();
            foreach (var ficPaItem in result)
            {
                FicMetItemsCEDIS.Add(ficPaItem);
            }

            var resultCedi = await FicLoSrvCatAlmacenes.FicMetGetCEDIS(FicLoZt_cat_almacenes);
            SelectedCEDI = new zt_cat_cedis();
            if (resultCedi != null)
            {
                SelectedCEDI = resultCedi;
            }

            base.OnAppearing(FicPaNavigationContext);
        }

        private async void SaveCommandExecute()
        {
            Item.FechaReg = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;

            var result = await FicLoSrvCatAlmacenes.FicMetGetListCatAlmacenes();
            var tmp = new Tmp();

            foreach (var ficPaItem in result)
            {
                if (ficPaItem.IdAlmacen.Equals(Item.IdAlmacen))
                {
                    await tmp.DisplayAlert("Advertencia", "El Id Almacén: " + Item.IdAlmacen + " ya existe. Favor de utilizar uno diferente.", "OK");
                    return;
                }
            }

            await FicLoSrvCatAlmacenes.FicMetInsertNewCatAlmacen(Item);
            FicLoSrvNavigationInventario.FicMetNavigateBack();
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationInventario.FicMetNavigateBack();
        }
    }

    public class Tmp : Page
    {

    }
    /*public class FicVmAlmacenItem : FicViewModelBase
    {

        private zt_cat_almacenes Fic_Zt_Cat_Almacenes_Item;

        private ICommand FicSaveCommand;
        //private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationInventario FicLoSrvNavigationInventario;
        private IFicSrvCatAlmacen FicLoSrvCatAlmacenes;

        public FicVmAlmacenItem(
            IFicSrvNavigationInventario FicPaSrvNavigationInventario,
            IFicSrvCatAlmacen FicPaSrvCatAlmacen)
        {
            FicLoSrvNavigationInventario = FicPaSrvNavigationInventario;
            FicLoSrvCatAlmacenes = FicPaSrvCatAlmacen;
        }

        public zt_cat_almacenes Item
        {
            get { return Fic_Zt_Cat_Almacenes_Item; }
            set
            {
                Fic_Zt_Cat_Almacenes_Item = value;
                RaisePropertyChanged();
            }
        }

        public ICommand FicMetSaveCommand
        {
            get { return FicSaveCommand = FicSaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        /*public ICommand FicMetDeleteCommand
        {
            get { return FicDeleteCommand = FicDeleteCommand ?? new FicVmDelegateCommand(DeleteCommandExecute); }
        }*/

    /*public ICommand FicMetCancelCommand
    {
        get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
    }

    public override void OnAppearing(object FicPaNavigationContext)
    {
        var FicLoZt_cat_almacenes = FicPaNavigationContext as zt_cat_almacenes;

        if (FicLoZt_cat_almacenes != null)
        {
            Item = FicLoZt_cat_almacenes;
        }

        base.OnAppearing(FicPaNavigationContext);
    }

    private async void SaveCommandExecute()
    {
        await FicLoSrvCatAlmacenes.FicMetInsertNewCatAlmacen(Item);
        FicLoSrvNavigationInventario.FicMetNavigateBack();
    }

    /*private async void DeleteCommandExecute()
    {
        await FicLoSrvCatAlmacenes.FicMetRemoveCatAlmacen(Item);
        FicLoSrvNavigationInventario.FicMetNavigateBack();
    }*/

    /*private void CancelCommandExecute()
    {
        FicLoSrvNavigationInventario.FicMetNavigateBack();
    }

}*/
}