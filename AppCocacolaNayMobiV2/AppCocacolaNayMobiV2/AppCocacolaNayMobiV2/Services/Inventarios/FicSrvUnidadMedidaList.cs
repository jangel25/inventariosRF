using AppCocacolaNayMobiV2.Helpers;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.SQLite;
using AppCocacolaNayMobiV2.Models.Inventarios;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCocacolaNayMobiV2.Services.Inventarios
{
    public class FicSrvUnidadMedidaList : IFicSrvUnidadMedida
    {
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        private SQLiteAsyncConnection ficSQLiteConnection;

        //FIC: Constructor
        public FicSrvUnidadMedidaList()
        {
            var ficDataBasePath = DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath();
            ficSQLiteConnection = new SQLiteAsyncConnection(ficDataBasePath);
            FicLoMetCreateDataBaseAsync();
        }


        public async void FicLoMetCreateDataBaseAsync()
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                await ficSQLiteConnection.CreateTableAsync<zt_cat_cedis>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_cat_almacenes>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_cat_unidad_medidas>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_cat_productos>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_inventarios>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_inventarios_det>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_inventarios_conteos>(CreateFlags.None).ConfigureAwait(false);
            }
        }

        #region zt_unidad_medida      
        public async Task<IList<zt_cat_unidad_medidas>> FicMetGetListUnidadMedida()
        {
            var items = new List<zt_cat_unidad_medidas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_cat_unidad_medidas>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }
        //Buscar
        public async Task<IList<zt_cat_unidad_medidas>> FicMetGetListUnidadMedida2(string FicPaFiltro)
        {
            var items = new List<zt_cat_unidad_medidas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_cat_unidad_medidas>()
                    .Where(x => x.IdUMedida == FicPaFiltro).ToListAsync().ConfigureAwait(false);
            }
            return items;
        }


        //FIC: Insertar el Inventario en la tabla.
        public async Task FicMetInsertNewUnidadMedida(zt_cat_unidad_medidas FicPaZt_unidadmedida_Item)
        {
            //ficSQLiteConexion.Insert(ficPaZtInventarios);
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_cat_unidad_medidas>()
                        .Where(x => x.Id == FicPaZt_unidadmedida_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_unidadmedida_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_unidadmedida_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_unidadmedida_Item).ConfigureAwait(false);
                }
            }
        }


        public async Task FicMetRemoveUnidadMedida(zt_cat_unidad_medidas FicPaZt_unidadmedida_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_unidadmedida_Item);
        }

        #endregion

    }
}
