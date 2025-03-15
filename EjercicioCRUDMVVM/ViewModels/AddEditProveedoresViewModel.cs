using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp3.Model;
using MauiApp3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMVVM.ViewModels
{
    public partial class AddEditProveedoresViewModel : ObservableObject
    {


        [ObservableProperty]
        private int id; 

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string fabrica;

        [ObservableProperty]
        private int telefono; 

        [ObservableProperty]
        private string producto;


        private readonly ProveedorService _service; 

        public AddEditProveedoresViewModel()
        {
            _service = new ProveedorService(); 

        }

        public AddEditProveedoresViewModel(Proveedor Proveedor)
        {
            _service = new ProveedorService();
            Id = Proveedor.Id;
            Nombre = Proveedor.NombreProveedor;
            Fabrica = Proveedor.Fabrica;
            Telefono = Proveedor.Telefono;
            Producto = Proveedor.Producto; 

        }


        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Proveedor Proveedor = new Proveedor();
                Proveedor.Id = Id;
                Proveedor.NombreProveedor = Nombre;
                Proveedor.Fabrica = Fabrica;
                Proveedor.Telefono = Telefono;
                Proveedor.Producto = Producto; 

                if(Id == 0)
                {
                    _service.Insert(Proveedor);
                }
                else
                {
                    _service.Update(Proveedor);
                }

                await App.Current!.MainPage!.Navigation.PopAsync(); 

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
