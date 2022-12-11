using App.Client_Interface;
using App.Controllers.Cache;
using App.Exceptions;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class AuthenticationController
    {
        IAuthenticationClient auth_client;

        public AuthenticationController(IAuthenticationClient authClient)
        {
            auth_client = authClient;
        }

        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            try
            {
                string tokenData = await auth_client.LoginAsync(loginModel);
                AccessToken.Instance.Data = tokenData;
                return true;
            }
            catch(WrongLoginException logEx)
            {
                throw new WrongLoginException($"Incorect login data={loginModel}. Message was {logEx.Message}");
            }
            catch(Exception ex)
            {
                throw new Exception($"Incorect login data={loginModel}. Message was {ex.Message}");
            }
        }
    }
}
