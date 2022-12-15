using App.Client_Interface;
using App.Cache;
using App.DTOs;
using App.Exceptions;
using Newtonsoft.Json.Linq;


namespace App.Controllers
{
    public class AuthenticationController
    {
        IAuthenticationClient auth_client;
        AccessToken accessToken = AccessToken.Instance;

        public AuthenticationController(IAuthenticationClient authClient)
        {
            auth_client = authClient;
        }

        public async Task<bool> LoginAsync(LoginModelDto loginModel)
        {
            try
            {
                var result = await auth_client.LoginAsync(loginModel);
                if(result != "")
                {
                    string? TokenString = (string?)JObject.Parse(result)["token"];
                    if(TokenString != null)
                    {
                        //accessToken.Data = TokenString;
                        //var instance = AccessToken.Instance;
                        //string s = accessToken.Data;
                        //Globals.Token = TokenString;
                        Globals.Authenticated = true;
                    }
                    
                }
                return true;
            }
            catch (WrongLoginException logEx)
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
