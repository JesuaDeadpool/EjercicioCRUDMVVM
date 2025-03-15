using EjercicioCRUDMVVM.Views;

namespace EjercicioCRUDMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new ProveedoresView()); 
        }
    }
}
