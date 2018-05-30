using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Services;
using AppCocacolaNayMobiV2.Services.Inventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCocacolaNayMobiV2.Views.REST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportExportxaml : ContentPage
    {

        public List<bool> res;

        public ImportExportxaml()
        {
            InitializeComponent();
            res = new List<bool>()
             {
                 false,
                 false,
                 false,
                 false,
                 false,
                 false,
                 false
             };
        }

        private async void importInv()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServiceInv();
            List<zt_inventarios> lista = new List<zt_inventarios>();

            foreach (zt_inventarios t in ws)
            {
                lista.Add(t);
            }
            await x.setXamarinInv(lista);
        }//IMPORTAR DESDE EL REST A XAMARIN

        private async void exportInv()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinInv();

            List<zt_inventarios> lista = new List<zt_inventarios>();

            foreach (zt_inventarios t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServiceInv(lista, true);
        }//EXPORTAR PARA EL REST

        private async void importAlm()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServiceAlm();
            List<zt_cat_almacenes> lista = new List<zt_cat_almacenes>();

            foreach (zt_cat_almacenes t in ws)
            {
                lista.Add(t);
            }
            await x.setXamarinAlm(lista);
        }//IMPORTAR DESDE EL REST A XAMARIN

        private async void exportAlm()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinAlm();

            List<zt_cat_almacenes> lista = new List<zt_cat_almacenes>();

            foreach (zt_cat_almacenes t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServiceAlm(lista, true);
        }//EXPORTAR PARA EL REST

        private async void importCed()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServiceCed();
            List<zt_cat_cedis> lista = new List<zt_cat_cedis>();

            foreach (zt_cat_cedis t in ws)
            {
                lista.Add(t);
            }
            await x.setXamarinCed(lista);
        }

        private async void exportCed()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinCed();

            List<zt_cat_cedis> lista = new List<zt_cat_cedis>();

            foreach (zt_cat_cedis t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServiceCed(lista, true);
        }

        private async void importDet()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServiceInd();
            List<zt_inventarios_det> lista = new List<zt_inventarios_det>();

            foreach (zt_inventarios_det t in ws)
            {
                lista.Add(t);
            }
            await x.setXamarinInd(lista);
        }

        private async void exportDet()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinInd();

            List<zt_inventarios_det> lista = new List<zt_inventarios_det>();

            foreach (zt_inventarios_det t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServiceInd(lista, true);
        }

        private async void importCon()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServiceInc();
            List<zt_inventarios_conteos> lista = new List<zt_inventarios_conteos>();

            foreach (zt_inventarios_conteos t in ws)
            {
                lista.Add(t);
            }
            await x.setXamarinInc(lista);
        }

        private async void exportCon()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinInc();

            List<zt_inventarios_conteos> lista = new List<zt_inventarios_conteos>();

            foreach (zt_inventarios_conteos t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServiceInc(lista, true);
        }

        private async void importProd()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServicePod();
            List<zt_cat_productos> list = new List<zt_cat_productos>();

            foreach (zt_cat_productos t in ws)
            {
                list.Add(t);
            }
            await x.setXamarinPod(list);
        }

        private async void exportProd()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinPod();

            List<zt_cat_productos> lista = new List<zt_cat_productos>();

            foreach (zt_cat_productos t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServicePod(lista, true);
        }

        private async void importUnm()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServiceUnm();
            List<zt_cat_unidad_medidas> lista = new List<zt_cat_unidad_medidas>();

            foreach (zt_cat_unidad_medidas t in ws)
            {
                lista.Add(t);
            }
            await x.setXamarinUnm(lista);
        }

        private async void exportUnm()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinUnm();

            List<zt_cat_unidad_medidas> lista = new List<zt_cat_unidad_medidas>();

            foreach (zt_cat_unidad_medidas t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServiceUnm(lista, true);
        }


        protected override async void OnAppearing()
        {
            /*
            SaveSqliteWS a = new SaveSqliteWS();
            await a.FicMetRemoveAllInventario();
            await DisplayAlert("BORRADO", "REGISTROS SQLITE BORRADOS CON EXITO", "OK");
            */
        }

        public void OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value) res[0] = true;
            else res[0] = false;
        }
        public void OnToggled2(object sender, ToggledEventArgs e)
        {
            if (e.Value) res[1] = true;
            else res[1] = false;
        }
        public void OnToggled3(object sender, ToggledEventArgs e)
        {
            if (e.Value) res[2] = true;
            else res[2] = false;
        }
        public void OnToggled4(object sender, ToggledEventArgs e)
        {
            if (e.Value) res[3] = true;
            else res[3] = false;
        }
        public void OnToggled5(object sender, ToggledEventArgs e)
        {
            if (e.Value) res[4] = true;
            else res[4] = false;
        }
        public void OnToggled6(object sender, ToggledEventArgs e)
        {
            if (e.Value) res[5] = true;
            else res[5] = false;
        }
        public void OnToggled7(object sender, ToggledEventArgs e)
        {
            if (e.Value) res[6] = true;
            else res[6] = false;
        }

        private void ImportClicked(object sender, EventArgs e)
        {
            if (res[0]) importInv();
            if (res[1]) importDet();
            if (res[2]) importCon();
            if (res[3]) importProd();
            if (res[4]) importUnm();
            if (res[5]) importCed();
            if (res[6]) importAlm();
            DisplayAlert("EXITO", "IMPORTADO", "OK");
        }//import
        private void ExportClicked(object sender, EventArgs e)
        {
            if (res[0]) exportInv();
            if (res[1]) exportDet();
            if (res[2]) exportCon();
            if (res[3]) exportProd();
            if (res[4]) exportUnm();
            if (res[5]) exportCed();
            if (res[6]) exportAlm();
            DisplayAlert("EXITO", "EXPORTADO", "OK");
        }//export

    }
}