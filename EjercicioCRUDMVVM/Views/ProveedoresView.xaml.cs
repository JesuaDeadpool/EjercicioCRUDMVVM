using EjercicioCRUDMVVM.ViewModels;

namespace EjercicioCRUDMVVM.Views;

public partial class ProveedoresView : ContentPage
{

	ProveedoresViewModel viewModel; 

	public ProveedoresView()
	{
		InitializeComponent();

		viewModel = new ProveedoresViewModel();
		this.BindingContext = viewModel; 

	}
}