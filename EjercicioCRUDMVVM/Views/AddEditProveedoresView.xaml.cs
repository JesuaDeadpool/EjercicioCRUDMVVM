using EjercicioCRUDMVVM.ViewModels;

namespace EjercicioCRUDMVVM.Views;

public partial class AddEditProveedoresView : ContentPage
{

	AddEditProveedoresViewModel viewModel; 
	public AddEditProveedoresView()
	{
		InitializeComponent();
		viewModel = new AddEditProveedoresViewModel();
		this.BindingContext = viewModel; 
	}
}