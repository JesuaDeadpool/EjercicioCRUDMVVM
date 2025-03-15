
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMVVM.Views;
using MauiApp3.Model;
using MauiApp3.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMVVM.ViewModels
{
    public partial class ProveedoresViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>(); 
        private ProveedorService _service; 


        public ProveedoresViewModel()
        {
            _service = new ProveedorService(); 
        }

      public void GetAll()
        {
            var getAll = _service.GetAll(); 

            if(getAll.Count > 0)
            {
                ProveedorCollection.Clear(); 

                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor); 
                }
            }


        }



        [RelayCommand]
        private async Task GoToAddEditProveedor()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditProveedoresView());
            //          
        }


        [RelayCommand]
        private async Task SelectProveedor(Proveedor proveedor)
        {

            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar",null, ACTUALIZAR, ELIMINAR);

                if(res == ACTUALIZAR)
                {
                    await App.Current!.MainPage!.Navigation!.PushAsync(new AddEditProveedoresView());
                }else if (res == ELIMINAR)
                {
                   bool respuesta =  await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR", "¿Desea eliminar el empleado?", "si", "no");


                    if (respuesta)
                    {
                        int del = _service.Delete(proveedor); 

                        if (del > 0)
                        {
                            Alerta("ELIMINAR PROVEEDOR", "Proveedor eliminado correctamente");
                            ProveedorCollection.Remove(proveedor);
                        }
                        else
                        {
                            Alerta("ELIMINAR PROVEEDOR", "No se a eliminado correctamente el proveedor");
                        }
                    }

                
                }

            }catch(Exception e)
            {
                Alerta("ERROR", e.Message); 
            }

        }

   

        private void Alerta(string Titulo, string Mensaje)

        {

            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));

        }
    }
}
