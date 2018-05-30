using AppCocacolaNayMobiV2.Models.Inventarios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCocacolaNayMobiV2.Interfaces.Inventarios
{
    public interface IFicSrvConteoDetInventario
    {
        //zt_inventarios_det
        Task<IList<zt_inventarios_det>> GetAll_zt_inventarios_det();
        Task Insert_zt_inventarios_det(zt_inventarios_det zt_Inventarios_det);
        Task Remove_zt_inventarios_det(zt_inventarios_det zt_Inventarios_det);

        //zt_inventarios_conteos
        Task<IList<zt_inventarios_conteos>> GetAll_zt_inventarios_conteos();
        Task Insert_zt_inventarios_conteos(zt_inventarios_conteos zt_Inventarios_conteos);
        Task Remove_zt_inventarios_conteos(zt_inventarios_conteos zt_Inventarios_conteos);

        //zt_cat_productos
        Task<IList<zt_cat_productos>> GetAll_zt_cat_productos();

        //zt_cat_unidades_medida
        Task<IList<zt_cat_unidad_medidas>> GetAll_zt_cat_unidad_medida();
    }
}
