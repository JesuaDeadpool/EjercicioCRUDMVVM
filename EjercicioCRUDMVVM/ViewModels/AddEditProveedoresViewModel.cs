using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp3.Model;
using MauiApp3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMVVM.ViewModels
{
    class AddEditProveedoresViewModel : ObservableObject
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


    }
}
