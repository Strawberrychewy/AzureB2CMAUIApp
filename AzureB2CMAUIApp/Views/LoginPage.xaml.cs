using AzureB2CMAUIApp.ViewModels;

namespace AzureB2CMAUIApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}