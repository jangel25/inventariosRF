using System.Windows.Input;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Base;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmUnidadMedidaDetalle : FicViewModelBase
    {
        private zt_cat_unidad_medidas Fic_Zt_unidadmedida_Item;

        private ICommand FicEditCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationUnidadMedida FicLoSrvNavigationUnidadMedida;
        private IFicSrvUnidadMedida FicLoSrvUnidadMedida;

        public FicVmUnidadMedidaDetalle(
            IFicSrvNavigationUnidadMedida FicPaSrvNavigationUnidadMedida,
            IFicSrvUnidadMedida FicPaSrvUnidadMedida)
        {
            FicLoSrvNavigationUnidadMedida = FicPaSrvNavigationUnidadMedida;
            FicLoSrvUnidadMedida = FicPaSrvUnidadMedida;
        }

        public zt_cat_unidad_medidas Item
        {
            get { return Fic_Zt_unidadmedida_Item; }
            set
            {
                Fic_Zt_unidadmedida_Item = value;
                RaisePropertyChanged();
            }
        }

        public ICommand FicMetEditCommand
        {
            get { return FicEditCommand = FicEditCommand ?? new FicVmDelegateCommand(EditCommandExecute); }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        public override void OnAppearing(object FicPaNavigationContext)
        {
            var FicLoZt_unidadmedida = FicPaNavigationContext as zt_cat_unidad_medidas;

            if (FicLoZt_unidadmedida != null)
            {
                Item = FicLoZt_unidadmedida;
            }

            base.OnAppearing(FicPaNavigationContext);
        }

        private void EditCommandExecute()
        {
            if (Fic_Zt_unidadmedida_Item != null)
            {
                FicLoSrvNavigationUnidadMedida.FicMetNavigateTo<FicVmUnidadMedidaEditar>(Fic_Zt_unidadmedida_Item);
            }
            Fic_Zt_unidadmedida_Item = null;
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationUnidadMedida.FicMetNavigateBack();
        }
    }
}
