using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppCocacolaNayMobiV2.Models.Inventarios;

namespace AppCocacolaNayMobiV2.Interfaces.Inventarios
{
    public interface IFicSrvUnidadMedida
    {
        Task<IList<zt_cat_unidad_medidas>> FicMetGetListUnidadMedida();
        Task FicMetInsertNewUnidadMedida(zt_cat_unidad_medidas FicPaZt_unidadmedida_Item);
        Task FicMetRemoveUnidadMedida(zt_cat_unidad_medidas FicPaZt_unidadmedida_Remove);
    }
}
