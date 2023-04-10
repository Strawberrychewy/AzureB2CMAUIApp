using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceMaker.AuthClient
{
    public interface IPCAWrapper
    {
        string[] Scopes { get; set; }
        Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes);
        Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes);

        Task SignOutAsync();
    }
}
