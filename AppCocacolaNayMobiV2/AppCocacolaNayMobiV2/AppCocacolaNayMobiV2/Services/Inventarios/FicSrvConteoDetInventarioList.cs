using AppCocacolaNayMobiV2.Helpers;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.SQLite;
using AppCocacolaNayMobiV2.Models.Inventarios;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCocacolaNayMobiV2.Services.Inventarios
{
    public class FicSrvConteoDetInventarioList : IFicSrvConteoDetInventario
    {
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        private SQLiteAsyncConnection ficSQLiteConnection;

        public FicSrvConteoDetInventarioList()
        {
            var ficDataBasePath = DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath();
            ficSQLiteConnection = new SQLiteAsyncConnection(ficDataBasePath);
            FicLoMetCreateDataBaseAsync();
        }//Fin constructor

        public async void FicLoMetCreateDataBaseAsync()
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                await ficSQLiteConnection.CreateTableAsync<zt_inventarios_det>().ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_inventarios_conteos>().ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<zt_cat_unidad_medidas>().ConfigureAwait(false);
            }
        }//Fin createDataBaseAsync

        public async Task<IList<zt_inventarios_det>> GetAll_zt_inventarios_det()
        {
            var zt_inventarios_det = new List<zt_inventarios_det>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                zt_inventarios_det = await ficSQLiteConnection.Table<zt_inventarios_det>().ToListAsync().ConfigureAwait(false);
            }

            return zt_inventarios_det;
        }//Fin GetAll

        public async Task Insert_zt_inventarios_det(zt_inventarios_det zt_inventarios_det)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var existingCountItem = await ficSQLiteConnection.Table<zt_inventarios_det>()
                        .Where(x => x.Id == zt_inventarios_det.Id)
                        .FirstOrDefaultAsync();

                if (existingCountItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(zt_inventarios_det).ConfigureAwait(false);
                }
                else
                {
                    zt_inventarios_det.Id = existingCountItem.Id;
                    await ficSQLiteConnection.UpdateAsync(zt_inventarios_det).ConfigureAwait(false);
                }
            }
        }//Fin insert

        public async Task Remove_zt_inventarios_det(zt_inventarios_det zt_inventarios_det)
        {
            await ficSQLiteConnection.DeleteAsync(zt_inventarios_det);
        }//Fin remove

        //Esto es para zt_inventarios_conteos
        public async Task<IList<zt_inventarios_conteos>> GetAll_zt_inventarios_conteos()
        {
            var zt_inventarios_conteos = new List<zt_inventarios_conteos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                zt_inventarios_conteos = await ficSQLiteConnection.Table<zt_inventarios_conteos>().ToListAsync().ConfigureAwait(false);
            }

            return zt_inventarios_conteos;
        }//Fin GetAll

        public async Task Insert_zt_inventarios_conteos(zt_inventarios_conteos zt_inventarios_conteos)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var existingCountItem = await ficSQLiteConnection.Table<zt_inventarios_conteos>()
                        .Where(x => x.Id == zt_inventarios_conteos.Id)
                        .FirstOrDefaultAsync();

                if (existingCountItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(zt_inventarios_conteos).ConfigureAwait(false);
                }
                else
                {
                    zt_inventarios_conteos.Id = existingCountItem.Id;
                    await ficSQLiteConnection.UpdateAsync(zt_inventarios_conteos).ConfigureAwait(false);
                }
            }
        }//Fin insert

        public async Task Remove_zt_inventarios_conteos(zt_inventarios_conteos zt_inventarios_conteos)
        {
            await ficSQLiteConnection.DeleteAsync(zt_inventarios_conteos);
        }//Fin remove

        //Esto es para zt_cat_unidad_medidas
        public async Task<IList<zt_cat_productos>> GetAll_zt_cat_productos()
        {
            var zt_cat_productos = new List<zt_cat_productos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                zt_cat_productos = await ficSQLiteConnection.Table<zt_cat_productos>().ToListAsync().ConfigureAwait(false);
            }

            return zt_cat_productos;
        }//Fin GetAll
    }
}//Fin clase

