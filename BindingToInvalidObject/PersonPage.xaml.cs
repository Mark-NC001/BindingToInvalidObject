using BindingToInvalidObject.ViewModels;

namespace BindingToInvalidObject;

public partial class PersonPage : ContentPage
{

	private PersonViewModel _viewModel;

	public PersonPage(PersonViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = _viewModel;


		ToolbarItems.Add(new ToolbarItem("Delete", null, async () =>
		{
			viewModel.Delete();
			await Navigation.PopModalAsync();
		}));

	}

	private void ClearName_Clicked(object sender, EventArgs e)
	{
		_viewModel.FirstName = string.Empty;
	}
}