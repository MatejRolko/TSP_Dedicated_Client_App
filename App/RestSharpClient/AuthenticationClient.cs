
using App.Client_Interface;
using App.DTOs;
using App.Exceptions;
using RestSharp;
using System.Net;

namespace App.RestSharpClient
{
    public class AuthenticationClient  : IAuthenticationClient
    {
        RestClient _client;
        public AuthenticationClient(string restUrl) => _client = new RestClient(restUrl);

        public async Task<string> LoginAsync(LoginModelDto loginModel)
        {
            RestRequest request = new RestRequest().AddBody(loginModel);
            //request.AddHeader("Bearer", )

            var response = await _client.ExecutePostAsync(request);
            if (response.StatusCode.Equals(HttpStatusCode.Forbidden))
            {
                throw new WrongLoginException($"Incorect login data={loginModel}. Message was {response.ErrorMessage}");
            }
            if (!response.IsSuccessful || response.Content == null)
            {
                throw new Exception($"Error loggin in author with login data={loginModel}. Message was {response.Content}");
            }
            return response.Content;
        }
    }
}
