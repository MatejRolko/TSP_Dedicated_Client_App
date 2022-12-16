using App.Client_Interface;
using App.Cache;
using App.DTOs;
using App.Exceptions;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace App.Controllers
{
    public class AuthenticationController
    {
        IAuthenticationClient auth_client;

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
                        JwtSecurityToken Jst = new(TokenString);
                        List<Claim> theApiClaims = (List<Claim>)Jst.Claims.ToList();
                        theApiClaims.Add(new Claim("token", TokenString));

                        var claimsIdentity = new ClaimsIdentity(theApiClaims, "Login");
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        string role = claimsPrincipal.FindFirst(ClaimTypes.Role).Value;
                        if (role.Equals("Admin"))
                        {
                            Globals.Authenticated = true;
                        }
                        
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
