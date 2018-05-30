using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.Services.Inventarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppCocacolaNayMobiV2.Services
{
    public class ConnectWebService
    {
        private HttpClient _Client = new HttpClient();
        private const string URL = "http://localhost:54052/ServiceInventarios.svc/";

        public async Task<ObservableCollection<zt_inventarios>> getWebServiceInv()
        {
            /*URL A USAR*/
            const string url = URL + "findallinv";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<zt_inventarios>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<zt_inventarios>(post);
        }//GET WEB SERVICE zt_inventarios

        public async Task setWebServiceInv(List<zt_inventarios> item, bool isNewItem = false)
        {
            /*URL A USAR*/
            const string url = URL + "createinv";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _Client.PostAsync(uri, content);
            }

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }
        }//POST WEB SERVICE zt_inventarios

        public async Task<ObservableCollection<zt_cat_almacenes>> getWebServiceAlm()
        {
            /*URL A USAR*/
            const string url = URL + "findallalm";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<zt_cat_almacenes>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<zt_cat_almacenes>(post);
        }//GET WEB SERVICE zt_cat_almacenes

        public async Task setWebServiceAlm(List<zt_cat_almacenes> item, bool isNewItem = false)
        {
            /*URL A USAR*/
            const string url = URL + "createalm";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _Client.PostAsync(uri, content);
            }

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }

        }//POST WEB SERVICE zt_cat_almacenes

        public async Task<ObservableCollection<zt_cat_cedis>> getWebServiceCed()
        {
            /*URL A USAR*/
            const string url = URL + "findallced";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<zt_cat_cedis>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<zt_cat_cedis>(post);
        }//GET WEB SERVICE zt_cat_cedis

        public async Task setWebServiceCed(List<zt_cat_cedis> item, bool isNewItem = false)
        {
            /*URL A USAR*/
            const string url = URL + "createced";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _Client.PostAsync(uri, content);
            }

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }

        }//POST WEB SERVICE zt_cat_cedis

        public async Task<ObservableCollection<zt_cat_productos>> getWebServicePod()
        {
            /*URL A USAR*/
            const string url = URL + "findallpod";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<zt_cat_productos>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<zt_cat_productos>(post);
        }//GET WEB SERVICE zt_cat_productos

        public async Task setWebServicePod(List<zt_cat_productos> item, bool isNewItem = false)
        {
            /*URL A USAR*/
            const string url = URL + "createpod";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _Client.PostAsync(uri, content);
            }

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }

        }//POST WEB SERVICE zt_cat_productos

        public async Task<ObservableCollection<zt_cat_unidad_medidas>> getWebServiceUnm()
        {
            /*URL A USAR*/
            const string url = URL + "findallunm";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<zt_cat_unidad_medidas>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<zt_cat_unidad_medidas>(post);
        }//GET WEB SERVICE zt_cat_unidad_medidas

        public async Task setWebServiceUnm(List<zt_cat_unidad_medidas> item, bool isNewItem = false)
        {
            /*URL A USAR*/
            const string url = URL + "createunm";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _Client.PostAsync(uri, content);
            }

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }

        }//POST WEB SERVICE zt_cat_unidad_medidas

        public async Task<ObservableCollection<zt_inventarios_conteos>> getWebServiceInc()
        {
            /*URL A USAR*/
            const string url = URL + "findallinc";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<zt_inventarios_conteos>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<zt_inventarios_conteos>(post);
        }//GET WEB SERVICE zt_inventarios_conteos

        public async Task setWebServiceInc(List<zt_inventarios_conteos> item, bool isNewItem = false)
        {
            /*URL A USAR*/
            const string url = URL + "createinc";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _Client.PostAsync(uri, content);
            }

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }

        }//POST WEB SERVICE zt_inventarios_conteos

        public async Task<ObservableCollection<zt_inventarios_det>> getWebServiceInd()
        {
            /*URL A USAR*/
            const string url = URL + "findallind";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<zt_inventarios_det>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<zt_inventarios_det>(post);
        }//GET WEB SERVICE zt_inventarios_det

        public async Task setWebServiceInd(List<zt_inventarios_det> item, bool isNewItem = false)
        {
            /*URL A USAR*/
            const string url = URL + "createind";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _Client.PostAsync(uri, content);
            }

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }

        }//POST WEB SERVICE zt_inventarios_det
    }

    public class ConnectXamarin
    {
        private SaveSqliteWS sqlite = new SaveSqliteWS();

        public async Task<IList<zt_inventarios>> getXamarinInv()
        {
            return await sqlite.FicMetGetListInventarios();
        }//GET XAMARIN zt_inventarios

        public async Task setXamarinInv(List<zt_inventarios> item)
        {
            var lista = await this.getXamarinInv();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].IdInventario == lista[dx].IdInventario)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    zt_inventarios inv = item[i];
                    await sqlite.FicMetInsertNewInventario(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL

        }//SET XAMARIN zt_inventarios

        public async Task<IList<zt_cat_almacenes>> getXamarinAlm()
        {
            return await sqlite.FicMetGetListAlmacenes();
        }//GET XAMARIN zt_cat_almacenes

        public async Task setXamarinAlm(List<zt_cat_almacenes> item)
        {
            var lista = await this.getXamarinAlm();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].IdAlmacen == lista[dx].IdAlmacen)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    zt_cat_almacenes inv = item[i];
                    await sqlite.FicMetInsertNewAlmacenes(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL
        }//SET XAMARIN zt_cat_almacenes

        public async Task<IList<zt_cat_cedis>> getXamarinCed()
        {
            return await sqlite.FicMetGetListCedis();
        }//GET XAMARIN zt_cat_cedis

        public async Task setXamarinCed(List<zt_cat_cedis> item)
        {
            var lista = await this.getXamarinCed();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].IdCEDI == lista[dx].IdCEDI)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    zt_cat_cedis inv = item[i];
                    await sqlite.FicMetInsertNewCedis(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL
        }//SET XAMARIN zt_cat_cedis

        public async Task<IList<zt_cat_productos>> getXamarinPod()
        {
            return await sqlite.FicMetGetListProductos();
        }//GET XAMARIN zt_cat_productos

        public async Task setXamarinPod(List<zt_cat_productos> item)
        {
            var lista = await this.getXamarinPod();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].SKU == lista[dx].SKU)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    zt_cat_productos inv = item[i];
                    await sqlite.FicMetInsertNewProductos(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL
        }//SET XAMARIN zt_cat_productos

        public async Task<IList<zt_cat_unidad_medidas>> getXamarinUnm()
        {
            return await sqlite.FicMetGetListUnidadMedidas();
        }//GET XAMARIN zt_cat_unidad_medidas

        public async Task setXamarinUnm(List<zt_cat_unidad_medidas> item)
        {
            var lista = await this.getXamarinUnm();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].IdUMedida == lista[dx].IdUMedida)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    zt_cat_unidad_medidas inv = item[i];
                    await sqlite.FicMetInsertNewUnidadMedidas(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL
        }//SET XAMARIN zt_cat_unidad_medidas

        public async Task<IList<zt_inventarios_conteos>> getXamarinInc()
        {
            return await sqlite.FicMetGetListInventariosConteos();
        }//GET XAMARIN zt_inventarios_conteos

        public async Task setXamarinInc(List<zt_inventarios_conteos> item)
        {
            var lista = await this.getXamarinInc();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].IdConteo == lista[dx].IdConteo)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    zt_inventarios_conteos inv = item[i];
                    await sqlite.FicMetInsertNewInventarioConteos(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL
        }//SET XAMARIN zt_inventarios_conteos

        public async Task<IList<zt_inventarios_det>> getXamarinInd()
        {
            return await sqlite.FicMetGetListInventariosDet();
        }//GET XAMARIN zt_inventarios_det

        public async Task setXamarinInd(List<zt_inventarios_det> item)
        {
            var lista = await this.getXamarinInd();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].SKU == lista[dx].SKU)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    zt_inventarios_det inv = item[i];
                    await sqlite.FicMetInsertNewInventarioDet(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL
        }//SET XAMARIN SERVICE zt_inventarios_det
    }
}
