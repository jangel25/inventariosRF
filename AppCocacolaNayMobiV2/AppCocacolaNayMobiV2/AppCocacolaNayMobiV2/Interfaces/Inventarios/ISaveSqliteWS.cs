using System;
using System.Collections.Generic;
using AppCocacolaNayMobiV2.Models.Inventarios;
using System.Text;
using System.Threading.Tasks;

namespace AppCocacolaNayMobiV2.Interfaces.Inventarios
{
    public interface ISaveSqliteWS
    {
        Task<IList<zt_inventarios>> FicMetGetListInventarios();
        Task FicMetInsertNewInventario(zt_inventarios FicPaZt_inventarios_Item);
        Task FicMetRemoveInventario(zt_inventarios FicPaZt_inventarios_Remove);
        Task FicMetRemoveAllInventario();
        Task<IList<zt_cat_almacenes>> FicMetGetListAlmacenes();
        Task FicMetRemoveAllAlmacenes();
        Task FicMetInsertNewAlmacenes(zt_cat_almacenes FicPaZt_inventarios_Item);
        Task<IList<zt_cat_cedis>> FicMetGetListCedis();
        Task FicMetRemoveAllCedis();
        Task FicMetInsertNewCedis(zt_cat_cedis FicPaZt_inventarios_Item);
        Task<IList<zt_cat_productos>> FicMetGetListProductos();
        Task FicMetRemoveAllProductos();
        Task FicMetInsertNewProductos(zt_cat_productos FicPaZt_inventarios_Item);
        Task<IList<zt_cat_unidad_medidas>> FicMetGetListUnidadMedidas();
        Task FicMetRemoveAllUnidadMedidas();
        Task FicMetInsertNewUnidadMedidas(zt_cat_unidad_medidas FicPaZt_inventarios_Item);
        Task<IList<zt_inventarios_conteos>> FicMetGetListInventariosConteos();
        Task FicMetRemoveAllInventarioConteos();
        Task FicMetInsertNewInventarioConteos(zt_inventarios_conteos FicPaZt_inventarios_Item);
        Task<IList<zt_inventarios_det>> FicMetGetListInventariosDet();
        Task FicMetRemoveAllInventarioDet();
        Task FicMetInsertNewInventarioDet(zt_inventarios_det FicPaZt_inventarios_Item);
    }
}
