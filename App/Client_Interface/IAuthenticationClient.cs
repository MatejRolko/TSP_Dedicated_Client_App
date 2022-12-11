using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client_Interface
{
    public interface IAuthenticationClient
    {
        public Task<String> LoginAsync(LoginModel loginModel);
    }
}
