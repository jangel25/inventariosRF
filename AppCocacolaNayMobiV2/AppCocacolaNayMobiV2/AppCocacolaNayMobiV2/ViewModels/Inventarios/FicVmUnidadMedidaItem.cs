using System.Windows.Input;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Base;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmUnidadMedidaItem : FicViewModelBase
    {
        private zt_cat_unidad_medidas Fic_Zt_unidadmedida_Item;

        private ICommand FicSaveCommand;

        private ICommand FicCancelCommand;

        private IFicSrvNavigationUnidadMedida FicLoSrvNavigationUnidadMedida;
        private IFicSrvUnidadMedida FicLoSrvUnidadMedida;


        public FicVmUnidadMedidaItem(
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

        public ICommand FicMetSaveCommand
        {
            get { return FicSaveCommand = FicSaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
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
        
        private async void SaveCommandExecute()
        {
            await FicLoSrvUnidadMedida.FicMetInsertNewUnidadMedida(Item);
            FicLoSrvNavigationUnidadMedida.FicMetNavigateBack();
        }
        
        private void CancelCommandExecute()
        {
            //DisplayAlert("CANCELADO",result.Text,"OK");
            FicLoSrvNavigationUnidadMedida.FicMetNavigateBack();
        }
    }
}
