using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using PaceMaker.AuthClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureB2CMAUIApp.Services.LoginService {
    public class LoginService : ILoginService 
    {
        private readonly ILogger<LoginService> _logger;
        private string _accessToken = string.Empty;
        private bool _isLoggedIn;
        private PCAWrapper _pcaWrapper;
        private PCASocialWrapper _pcaSocialWrapper;

        public LoginService(ILogger<LoginService> logger, IConfiguration configuration) {
            _logger = logger;
            _pcaWrapper = new PCAWrapper(configuration);
            _pcaSocialWrapper = new PCASocialWrapper(configuration);
        }

        public async Task<bool> Login() {
            return await Login(_pcaWrapper);
        }
        public async Task<bool> LoginSocial() {
            return await Login(_pcaSocialWrapper);
        }

        private async Task<bool> Login(IPCAWrapper pcaWrapper) {
            //var accessToken = await SecureStorage.GetAsync("oauth_token");
            try {
                // Attempt silent login, and obtain access token.
                var result = await pcaWrapper.AcquireTokenSilentAsync(pcaWrapper.Scopes);
                _isLoggedIn = true;

                // Set access token.
                _accessToken = result.AccessToken;
                //await SecureStorage.Default.SetAsync("oauth_token", result.AccessToken);

                // Display Access Token from AcquireTokenSilentAsync call.
                await ShowOkMessage("Access Token from AcquireTokenSilentAsync call", _accessToken);
                return true;
            }
            // A MsalUiRequiredException will be thrown, if this is the first attempt to login, or after logging out.
            catch (MsalUiRequiredException) {
                // Perform interactive login, and obtain access token.
                var result = await pcaWrapper.AcquireTokenInteractiveAsync(pcaWrapper.Scopes).ConfigureAwait(false);
                _isLoggedIn = true;

                // Set access token.
                _accessToken = result.AccessToken;
                //await SecureStorage.Default.SetAsync("oauth_token", result.AccessToken);

                // Display Access Token from AcquireTokenInteractiveAsync call.
                await ShowOkMessage("Access Token from AcquireTokenInteractiveAsync call", _accessToken);
                return true;
            } catch (Exception ex) {
                _isLoggedIn = false;
                await ShowOkMessage("Exception in AcquireTokenSilentAsync", ex.Message);
                return false;
            }
        }
        public async Task Logout() {
            // Log out from Microsoft.
            await _pcaWrapper.SignOutAsync().ConfigureAwait(false);
            await _pcaSocialWrapper.SignOutAsync().ConfigureAwait(false);

            await ShowOkMessage("Signed Out", "Sign out complete.").ConfigureAwait(false);
            _isLoggedIn = false;
            _accessToken = string.Empty;
        }
        private async Task ShowOkMessage(string title, string message) {
            await Application.Current.Dispatcher.DispatchAsync(async () => {
                await Application.Current.MainPage.DisplayAlert(title, message, "OK");
            });
        }
    }
}
