using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCocacolaNayMobiV2.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMDP1Master : ContentPage
    {
        public ListView ListView;

        public FicMDP1Master()
        {
            InitializeComponent();

            BindingContext = new FicMDP1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class FicMDP1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FicMDP1MenuItem> MenuItems { get; set; }
            
            public FicMDP1MasterViewModel()
            {
                MenuItems = new ObservableCollection<FicMDP1MenuItem>(new[]
                {
                    //new FicMDP1MenuItem { Id = 0, Title = "Page 1" },
                    //new FicMDP1MenuItem { Id = 1, Title = "Page 2" },
                    //new FicMDP1MenuItem { Id = 2, Title = "Page 3" },
                    //new FicMDP1MenuItem { Id = 3, Title = "Page 4" },
                    //new FicMDP1MenuItem { Id = 4, Title = "Page 5" },

                    new FicMDP1MenuItem { Id = 0, Title = "Conteo de Inventario",
                                                Icon ="ficAlmacen20x20.png", ficPageName="FicViCpInventariosDetList"},
                    new FicMDP1MenuItem { Id = 1, Title = "Descargar Inventario", Icon="ficAlmacen20x20.png" },
                    new FicMDP1MenuItem { Id = 2, Title = "Cat. Unidad Medida", Icon="ficAlmacen20x20.png", ficPageName="FicViCpUnidadMedidaList" },
                    new FicMDP1MenuItem { Id = 3, Title = "Opcion 4", Icon="ficAlmacen20x20.png" },
                    new FicMDP1MenuItem { Id = 4, Title = "Salir", Icon="ficAlmacen20x20.png" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}