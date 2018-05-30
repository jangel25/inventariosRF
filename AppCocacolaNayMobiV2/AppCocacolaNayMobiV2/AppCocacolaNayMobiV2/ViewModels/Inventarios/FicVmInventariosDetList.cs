//using Acr.UserDialogs;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmInventariosDetList : FicViewModelBase
    {
        private ObservableCollection<conteo_inventario> FicOcZt_inventarios_det_Items;
        private conteo_inventario FicZt_inventarios_det_SelectedItem;

        private IFicSrvNavigationInventario FicLoSrvNavigationInventario;
        private IFicSrvConteoInventario FicLoSrvConteoInventario;

        public FicVmInventariosDetList(
            IFicSrvNavigationInventario ficPaSrvNavigationInventario,
            IFicSrvConteoInventario ficPaSrvConteoInventario)
        {
            FicLoSrvNavigationInventario = ficPaSrvNavigationInventario; 
            FicLoSrvConteoInventario = ficPaSrvConteoInventario;
        }

        public ObservableCollection<conteo_inventario> FicMetZt_inventarios_det_Items
        {
            get { return FicOcZt_inventarios_det_Items; }
            set
            {
                FicOcZt_inventarios_det_Items = value;
                RaisePropertyChanged();
            }
        }
        public conteo_inventario FicMetZt_inventarios_det_SelectedItem
        {
            get { return FicZt_inventarios_det_SelectedItem; }
            set
            {
                FicZt_inventarios_det_SelectedItem = value;
            }
        }
        private string _idInventario;
        public string IdInventario
        {
            get
            {
                return _idInventario;
            }
            set
            {
                if (_idInventario != value)
                {
                    _idInventario = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _fechaReg;
        public string FechaReg
        {
            get
            {
                return _fechaReg;
            }
            set
            {
                if (_fechaReg != value)
                {
                    _fechaReg = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override async void OnAppearing(object navigationContext)
        {
            var FicLoZt_inventarios = navigationContext as zt_inventarios;
            //var result = await FicLoSrvConteoInventario.FicMetGetListInventariosDet();
            base.OnAppearing(navigationContext);

            //DATOS DEL REGISTRO QUE SE LE PASA COMO PARAMETRO
            IdInventario = FicLoZt_inventarios.IdInventario+"";
            FechaReg = FicLoZt_inventarios.FechaReg;
            
            var result = await FicLoSrvConteoInventario.FicMetGetListInventariosCont(FicLoZt_inventarios);
            var reslPorSkUbUm = new List<zt_inventarios_conteos>();
            FicMetZt_inventarios_det_Items = new ObservableCollection<conteo_inventario>();
            bool bandera = true;

            foreach (var itemRes in result)
            {
                foreach (var itemReslPor in reslPorSkUbUm)
                {
                    if (itemRes.SKU.Equals(itemReslPor.SKU) &&
                        itemRes.IdUbicacion.Equals(itemReslPor.IdUbicacion) &&
                        itemRes.IdUMedida.Equals(itemReslPor.IdUMedida))
                    {
                        if (itemRes.CantFisica > itemReslPor.CantFisica)
                        {
                            itemReslPor.CantFisica = itemRes.CantFisica;
                        }
                        bandera = false;
                        break;
                    }
                    bandera = true;
                }
                if (bandera)
                {
                    reslPorSkUbUm.Add(itemRes);
                }
                bandera = false;
            }

            bandera = true;
            foreach (var itemReslPor in reslPorSkUbUm)
            {
                foreach (var itemFinal in FicMetZt_inventarios_det_Items)
                {
                    if (itemReslPor.SKU == itemFinal.SKU)
                    {
                        itemFinal.conteo += await FicLoSrvConteoInventario.convertiEnPzas(itemReslPor.IdUMedida,
                                                                                    itemReslPor.CantFisica);
                        bandera = false;
                        break;
                    }
                    bandera = true;
                }
                if (bandera)
                {
                    var temp = new conteo_inventario();
                    temp.SKU = itemReslPor.SKU;
                    temp.conteo = await FicLoSrvConteoInventario.convertiEnPzas(itemReslPor.IdUMedida,
                                                                                    itemReslPor.CantFisica); ;
                    temp.IdUbicacion = "";
                    temp.pzas = 2;

                    FicMetZt_inventarios_det_Items.Add(temp);
                }
                bandera = false;
            }
        }
    }
}
