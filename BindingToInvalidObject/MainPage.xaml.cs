using BindingToInvalidObject.ViewModels;

namespace BindingToInvalidObject
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void CreatePerson_Clicked(object sender, EventArgs e)
		{
			PersonViewModel viewModel = new PersonViewModel();
			NavigationPage navigationPage = new NavigationPage(new PersonPage(viewModel));

			await Navigation.PushModalAsync(navigationPage);
		}
	}

}
