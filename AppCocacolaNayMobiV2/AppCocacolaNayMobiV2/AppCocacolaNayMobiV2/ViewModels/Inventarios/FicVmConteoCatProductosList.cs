using System.Collections.ObjectModel;
using System.Windows.Input;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Base;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmConteoCatProductosList : FicViewModelBase
    {
        private ObservableCollection<zt_cat_productos> FicOcZt_cat_productos_Items;
        private zt_cat_productos FicZt_cat_productos_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;

        private IFicSrvNavigationCatProductos FicLoSrvNavigationCatProductos;
        private IFicSrvCatProductos FicLoSrvCatProductos;

        //FIC: Constructor
        public FicVmConteoCatProductosList(
            IFicSrvNavigationCatProductos ficPaSrvNavigationCatProductos,
            IFicSrvCatProductos ficPaSrvCatProductos)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatProductos = ficPaSrvNavigationCatProductos;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatProductos = ficPaSrvCatProductos;
        }
        public string busqueda
        {
            get { return _busqueda; }
            set { _busqueda = value; }
        }

        //FIC: Metodo para obtener la lista de registros de inventarios
        public ObservableCollection<zt_cat_productos> FicMetZt_cat_productos_Items
        {
            get { return FicOcZt_cat_productos_Items; }
            set
            {
                FicOcZt_cat_productos_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public zt_cat_productos FicMetZt_cat_productos_SelectedItem
        {
            get { return FicZt_cat_productos_SelectedItem; }
            set
            {
                FicZt_cat_productos_SelectedItem = value;
                FicLoSrvNavigationCatProductos.FicMetNavigateTo<FicVmConteoCatProductosDetalle>(FicZt_cat_productos_SelectedItem);
            }
        }

        //FIC: Metodo de tipo comando para agregar un registro 
        public ICommand ficMetAddCommand
        {
            get { return ficAddCommand = ficAddCommand ?? new FicVmDelegateCommand(AddCommandExecute); }
        }

        public ICommand ficMetSearch
        {
            get { return ficSearch = ficSearch ?? new FicVmDelegateCommand(Find); }
        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            //FIC: Ejecuto uno de los metodos definidos en los servicios de Interfaz de inventarios
            var result = await FicLoSrvCatProductos.FicMetGetListCatProductos();

            FicMetZt_cat_productos_Items = new ObservableCollection<zt_cat_productos>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_cat_productos_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new zt_cat_productos();
            FicLoSrvNavigationCatProductos.FicMetNavigateTo<FicVmConteoCatProductosItem>(ficZt_cat_productos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatProductos.FicMetGetListCatProductos();
                FicMetZt_cat_productos_Items = new ObservableCollection<zt_cat_productos>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_cat_productos_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatProductos.FicSearchCatProductos(busqueda);

                FicMetZt_cat_productos_Items = new ObservableCollection<zt_cat_productos>();

                if (FicMetZt_cat_productos_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_cat_productos_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}
