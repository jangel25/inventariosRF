using System.Collections.ObjectModel;
using System.Windows.Input;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Base;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmUnidadMedidaList : FicViewModelBase
    {
        private ObservableCollection<zt_cat_unidad_medidas> FicOcZt_unidadmedida_Items;
        private zt_cat_unidad_medidas FicZt_unidadmedida_SelectedItem;

        private ICommand ficAddCommand;
        private ICommand ficEditCommand;
        private ICommand ficDeleteCommand;
        private ICommand ficDetailCommand;

        private IFicSrvNavigationUnidadMedida FicLoSrvNavigationUnidadMedida;
        private IFicSrvUnidadMedida FicLoSrvUnidadMedida;


        public FicVmUnidadMedidaList(
            IFicSrvNavigationUnidadMedida ficPaSrvNavigationUnidadMedida,
            IFicSrvUnidadMedida ficPaSrvUnidadMedida)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationUnidadMedida = ficPaSrvNavigationUnidadMedida;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvUnidadMedida = ficPaSrvUnidadMedida;
        }

        //FIC: Metodo para obtener la lista de registros de inventarios
        public ObservableCollection<zt_cat_unidad_medidas> FicMetZt_unidadmedida_Items
        {
            get { return FicOcZt_unidadmedida_Items; }
            set
            {
                FicOcZt_unidadmedida_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public zt_cat_unidad_medidas FicMetZt_unidadmedida_SelectedItem
        {
            get { return FicZt_unidadmedida_SelectedItem; }
            set
            {
                FicZt_unidadmedida_SelectedItem = value;
                //FicLoSrvNavigationUnidadMedida.FicMetNavigateTo<FicVmUnidadMedidaItem>(FicZt_unidadmedida_SelectedItem);
            }
        }

        public ICommand ficMetAddCommand
        {
            get { return ficAddCommand = ficAddCommand ?? new FicVmDelegateCommand(AddCommandExecute); }
        }

        public ICommand ficMetEditCommand
        {
            get { return ficEditCommand = ficEditCommand ?? new FicVmDelegateCommand(EditCommandExecute); }
        }

        public ICommand ficMetDeleteCommand
        {
            get { return ficDeleteCommand = ficDeleteCommand ?? new FicVmDelegateCommand(DeleteCommandExecute); }
        }

        public ICommand ficMetDetailCommand
        {
            get { return ficDetailCommand = ficDetailCommand ?? new FicVmDelegateCommand(DetailCommandExecute); }
        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            var result = await FicLoSrvUnidadMedida.FicMetGetListUnidadMedida();

            FicMetZt_unidadmedida_Items = new ObservableCollection<zt_cat_unidad_medidas>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_unidadmedida_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_unidadmedida = new zt_cat_unidad_medidas();
            FicLoSrvNavigationUnidadMedida.FicMetNavigateTo<FicVmUnidadMedidaItem>(ficZt_unidadmedida);
        }
        private void EditCommandExecute()
        {
            if (FicZt_unidadmedida_SelectedItem != null)
            {
                FicLoSrvNavigationUnidadMedida.FicMetNavigateTo<FicVmUnidadMedidaEditar>(FicZt_unidadmedida_SelectedItem);
            }
            FicZt_unidadmedida_SelectedItem = null;
        }

        private void DeleteCommandExecute()
        {
            if (FicZt_unidadmedida_SelectedItem != null)
            {
                FicLoSrvNavigationUnidadMedida.FicMetNavigateTo<FicVmUnidadMedidaEliminar>(FicZt_unidadmedida_SelectedItem);
            }
            FicZt_unidadmedida_SelectedItem = null;
        }

        private void DetailCommandExecute()
        {
            if (FicZt_unidadmedida_SelectedItem != null)
            {
                FicLoSrvNavigationUnidadMedida.FicMetNavigateTo<FicVmUnidadMedidaDetalle>(FicZt_unidadmedida_SelectedItem);
            }
            FicZt_unidadmedida_SelectedItem = null;
        }
    }
}
