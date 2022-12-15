

using App.DTOs;

namespace App.Client_Interface
{
    public interface IAuthenticationClient
    {
        public Task<String> LoginAsync(LoginModelDto loginModel);
    }
}
