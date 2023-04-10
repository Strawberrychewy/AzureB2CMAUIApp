using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureB2CMAUIApp.Services.LoginService {
    public interface ILoginService 
    {
        Task<bool> Login();
        Task<bool> LoginSocial();
        Task Logout();
    }
}
