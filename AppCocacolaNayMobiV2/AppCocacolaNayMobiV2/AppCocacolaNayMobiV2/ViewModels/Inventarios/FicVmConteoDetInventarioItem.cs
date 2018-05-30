﻿using AppCocacolaNayMobiV2.Interfaces.Navigation;
using AppCocacolaNayMobiV2.Interfaces.Inventarios;
using AppCocacolaNayMobiV2.Models.Inventarios;
using AppCocacolaNayMobiV2.ViewModels.Base;
using System.Windows.Input;
using System;
using Syncfusion.SfDataGrid.XForms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace AppCocacolaNayMobiV2.ViewModels.Inventarios
{
    public class FicVmConteoDetInventarioItem : FicViewModelBase
    {

        public bool editar;
        public bool existeProducto;

        private zt_inventarios_conteos _zt_inventarios_conteos;
        private ObservableCollection<zt_cat_productos> _zt_cat_productos;
        public zt_cat_productos _selected_zt_cat_productos;

        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;
        private ICommand _findProductoSKU;
        private ICommand _findProductoCodBarras;

        private IFicSrvNavigationConteoDetInventario _navigationService;
        private IFicSrvConteoDetInventario _sqliteService;

        public FicVmConteoDetInventarioItem(
            IFicSrvNavigationConteoDetInventario navigationService,
            IFicSrvConteoDetInventario sqliteService)
        {
            _navigationService = navigationService;
            _sqliteService = sqliteService;
        }//Fin constructor

        public ObservableCollection<zt_cat_productos> Zt_cat_productos_list
        {
            get { return _zt_cat_productos; }
            set
            {
                _zt_cat_productos = value;
                RaisePropertyChanged();
            }
        }//Fin Zt_cat_productos_list

        public zt_inventarios_conteos Zt_inventario_conteos
        {
            get { return _zt_inventarios_conteos; }
            set
            {
                _zt_inventarios_conteos = value;
                RaisePropertyChanged();
            }
        }//Fin zt_inventario_conteos

        public ICommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand = _deleteCommand ?? new FicVmDelegateCommand(DeleteCommandExecute); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand = _cancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        /*public ICommand FindProductoSKU
        {
            get { return _findProductoSKU = _findProductoSKU ?? new FicVmDelegateCommand(FindProductoSKUExecute); }
        }

        public ICommand FindProductoCodBarras
        {
            get { return _findProductoCodBarras = _findProductoCodBarras ?? new FicVmDelegateCommand(FindProductoCodBarrasExecute); }
        }*/

        public override async void OnAppearing(object navigationContext)
        {
            var zt_inventario_conteosItem = navigationContext as zt_inventarios_conteos;

            if (zt_inventario_conteosItem != null)
            {
                Zt_inventario_conteos = zt_inventario_conteosItem;
            }

            base.OnAppearing(navigationContext);

            //Esto se utiliza para tener una lista con la cual comparar
            //si un producto existe o no
            var result = await _sqliteService.GetAll_zt_cat_productos();

            Zt_cat_productos_list = new ObservableCollection<zt_cat_productos>();
            foreach (var zt_cat_productos in result)
            {
                    Zt_cat_productos_list.Add(zt_cat_productos);
            }
            //base.OnAppearing(navigationContext);
        }//Fin OnAppearing

        private async void SaveCommandExecute()
        {
            Zt_inventario_conteos.UsuarioReg = "Brian Alejandro Casas López";
            Zt_inventario_conteos.FechaReg = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
            Zt_inventario_conteos.HoraReg = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            Console.WriteLine("VALOOOOOOR ");
            //Zt_inventario_conteos.IdInventario = Zt_inventario_det.IdInventario;

            await _sqliteService.Insert_zt_inventarios_conteos(Zt_inventario_conteos);
            _navigationService.NavigateBack();
        }//Fin SaveCommandExecute

        private async void DeleteCommandExecute()
        {
            await _sqliteService.Remove_zt_inventarios_conteos(Zt_inventario_conteos);
            _navigationService.NavigateBack();
        }//Fin DeleteCommandExecute

        private void CancelCommandExecute()
        {
            _navigationService.NavigateBack();
        }//Fin cancelCommandExecute

        public bool FindProductoSKUExecute(string SKU)
        {
            for (int i = 0; i < Zt_cat_productos_list.Count; i++) {
                if (Zt_cat_productos_list[i].SKU == SKU) {
                    _selected_zt_cat_productos = Zt_cat_productos_list[i];
                }
            }

            if (_selected_zt_cat_productos != null)
            {
                return true;
            }

            return false;
        }

        //Falta implementar este metodo
        public bool FindProductoCodBarrasExecute(string codBarras)
        {
            for (int i = 0; i < Zt_cat_productos_list.Count; i++)
            {
                if (Zt_cat_productos_list[i].CodigoBarras == codBarras)
                {
                    _selected_zt_cat_productos = Zt_cat_productos_list[i];
                }
            }

            if (_selected_zt_cat_productos != null)
            {
                return true;
            }

            return false;
        }
    }
}