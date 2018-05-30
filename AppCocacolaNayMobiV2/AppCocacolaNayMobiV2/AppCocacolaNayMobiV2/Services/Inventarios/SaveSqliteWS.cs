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
    public class SaveSqliteWS : ISaveSqliteWS
    {
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        private SQLiteAsyncConnection ficSQLiteConnection;

        //FIC: Constructor
        public SaveSqliteWS()
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

        public async Task<IList<zt_cat_almacenes>> FicMetGetListAlmacenes()
        {
            var items = new List<zt_cat_almacenes>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_cat_almacenes>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetRemoveAllAlmacenes()
        {
            await ficSQLiteConnection.DeleteAllAsync<zt_cat_almacenes>();
        }

        public async Task<IList<zt_cat_cedis>> FicMetGetListCedis()
        {
            var items = new List<zt_cat_cedis>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_cat_cedis>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetRemoveAllCedis()
        {
            await ficSQLiteConnection.DeleteAllAsync<zt_cat_cedis>();
        }

        public async Task<IList<zt_inventarios>> FicMetGetListInventarios()
        {
            var items = new List<zt_inventarios>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_inventarios>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<zt_inventarios_conteos>> FicMetGetListInventariosConteos()
        {
            var items = new List<zt_inventarios_conteos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_inventarios_conteos>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<zt_inventarios_det>> FicMetGetListInventariosDet()
        {
            var items = new List<zt_inventarios_det>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_inventarios_det>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<IList<zt_cat_productos>> FicMetGetListProductos()
        {
            var items = new List<zt_cat_productos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_cat_productos>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetRemoveAllProductos()
        {
            await ficSQLiteConnection.DeleteAllAsync<zt_cat_productos>();
        }

        public async Task<IList<zt_cat_unidad_medidas>> FicMetGetListUnidadMedidas()
        {
            var items = new List<zt_cat_unidad_medidas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<zt_cat_unidad_medidas>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetRemoveAllUnidadMedidas()
        {
            await ficSQLiteConnection.DeleteAllAsync<zt_cat_unidad_medidas>();
        }

        public async Task FicMetInsertNewAlmacenes(zt_cat_almacenes FicPaZt_inventarios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_cat_almacenes>()
                        .Where(x => x.Id == FicPaZt_inventarios_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_inventarios_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
            }
        }

        public async Task FicMetInsertNewCedis(zt_cat_cedis FicPaZt_inventarios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_cat_cedis>()
                        .Where(x => x.Id == FicPaZt_inventarios_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_inventarios_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
            }
        }

        public async Task FicMetInsertNewInventario(zt_inventarios FicPaZt_inventarios_Item)
        {
            //ficSQLiteConexion.Insert(ficPaZtInventarios);
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_inventarios>()
                        .Where(x => x.Id == FicPaZt_inventarios_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_inventarios_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
            }
        }

        public async Task FicMetInsertNewInventarioConteos(zt_inventarios_conteos FicPaZt_inventarios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_inventarios_conteos>()
                        .Where(x => x.Id == FicPaZt_inventarios_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_inventarios_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
            }
        }

        public async Task FicMetInsertNewInventarioDet(zt_inventarios_det FicPaZt_inventarios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_inventarios_det>()
                        .Where(x => x.Id == FicPaZt_inventarios_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_inventarios_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
            }
        }

        public async Task FicMetInsertNewProductos(zt_cat_productos FicPaZt_inventarios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_cat_productos>()
                        .Where(x => x.Id == FicPaZt_inventarios_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_inventarios_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
            }
        }

        public async Task FicMetInsertNewUnidadMedidas(zt_cat_unidad_medidas FicPaZt_inventarios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<zt_cat_unidad_medidas>()
                        .Where(x => x.Id == FicPaZt_inventarios_Item.Id)
                        .FirstOrDefaultAsync();

                if (FicExistingInventarioItem == null)
                {
                    await ficSQLiteConnection.InsertAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPaZt_inventarios_Item.Id = FicExistingInventarioItem.Id;
                    await ficSQLiteConnection.UpdateAsync(FicPaZt_inventarios_Item).ConfigureAwait(false);
                }
            }
        }

        public async Task FicMetRemoveInventario(zt_inventarios FicPaZt_inventarios_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_inventarios_Item);
        }

        public async Task FicMetRemoveAllInventario()
        {
            await ficSQLiteConnection.DeleteAllAsync<zt_inventarios>();
        }

        public async Task FicMetRemoveAllInventarioConteos()
        {
            await ficSQLiteConnection.DeleteAllAsync<zt_inventarios_conteos>();
        }

        public async Task FicMetRemoveAllInventarioDet()
        {
            await ficSQLiteConnection.DeleteAllAsync<zt_inventarios_det>();
        }
    }
}
