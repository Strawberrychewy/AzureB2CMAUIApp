using AzureB2CMAUIApp.Services.LoginService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;

namespace AzureB2CMAUIApp.ViewModels {
    public partial class LoginPageViewModel : ObservableObject    
    {
        ILoginService _loginService;

        public LoginPageViewModel(IConfiguration configuration, ILoginService loginService) {
            _loginService = loginService;
        }

        [RelayCommand]
        public async Task LoginUser() {
            Console.WriteLine("Loginuser pressed");
            var validLogin = await _loginService.Login();

            if (validLogin) {
                Application.Current.MainPage = new AppShell();
            }

            Console.WriteLine("Loginuser completed");
        }

        [RelayCommand]
        public async Task LoginSocialUser() {
            Console.WriteLine("Loginusersocial pressed");
            var validLogin = await _loginService.LoginSocial();

            if (validLogin) {
                Application.Current.MainPage = new AppShell();
            }

            Console.WriteLine("Loginusersocial completed");
        }

        [RelayCommand]
        public async Task LogoutUser() {
            Console.WriteLine("Loginuser pressed");
            await _loginService.Logout();
            Console.WriteLine("Logoutuser completed");
        }
    }
}
