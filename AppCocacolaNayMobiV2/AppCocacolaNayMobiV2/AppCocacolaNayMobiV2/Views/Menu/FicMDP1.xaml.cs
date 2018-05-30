using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCocacolaNayMobiV2.Views.Inventarios;

namespace AppCocacolaNayMobiV2.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMDP1 : MasterDetailPage
    {
        public FicMDP1()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var item = e.SelectedItem as FicMDP1MenuItem;
            //if (item == null)
            //    return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);
            //IsPresented = false;

            //MasterPage.ListView.SelectedItem = null;









            var ficItemMenu = e.SelectedItem as FicMDP1MenuItem;
            if (ficItemMenu == null)
                return;

            var ficPagina = ficItemMenu.ficPageName as string;

            switch (ficPagina)
            {
                case "FicViCpInventariosDetList":
                    ficItemMenu.TargetType = typeof(FicViCpInventariosDetList);
                    break;
                case "FicViCpUnidadMedidaList":
                    ficItemMenu.TargetType = typeof(FicViCpUnidadMedidaList);
                    break;
                default:
                    break;

            }

            var page = (Page)Activator.CreateInstance(ficItemMenu.TargetType);
            page.Title = ficItemMenu.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}