
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMVVM.ViewModels
{
    public partial class ProveedoresViewModel : ObservableObject
    {



        [RelayCommand]
        private async Task GoToAddEditProveedor()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditProveedoresView()); 
        }
    }
}
