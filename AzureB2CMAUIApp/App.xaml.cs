using AzureB2CMAUIApp.Views;

namespace AzureB2CMAUIApp;

public partial class App : Application
{
	/*
	 * Currently, the user login flow does not redirect once a Shell page has been navigated to.
	 * 
	 * If you uncomment the code and comment out the active code, you should see the difference between using these two pages
	 * when clicking on "Login User (Social)" within the login screen
	 */

	//#1
	//public App(AppShell appShell)
	public App(LoginPage page)
	{
		InitializeComponent();

		//#2
		//MainPage = appShell;
		MainPage = page;
	}
}
