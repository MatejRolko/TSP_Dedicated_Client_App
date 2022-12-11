
using App.Client_Interface;
using App.Exceptions;
using App.Model;
using RestSharp;
using System.Net;

namespace App.RestSharpClient
{
    public class AuthenticationClient  : IAuthenticationClient
    {
        RestClient _client;
        public AuthenticationClient(string restUrl) => _client = new RestClient(restUrl);

        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            var request = new RestRequest().AddBody(loginModel);
            try
            {
                var response = await _client.PostAsync(request);
                if (!response.IsSuccessful)
                {
                    throw new Exception($"Error loggin in author with login data={loginModel}. Message was {response.Content}");
                }
                return response.Content;
            }
            catch(HttpRequestException requestException)
            {
                if (requestException.StatusCode.Equals(HttpStatusCode.Forbidden))
                {
                    throw new WrongLoginException($"Incorect login data={loginModel}. Message was {requestException.Message}");
                }
                throw requestException;
            }
        }
    }
}
