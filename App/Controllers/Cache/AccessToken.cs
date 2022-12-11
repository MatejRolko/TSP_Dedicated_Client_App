using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Controllers.Cache
{
    sealed class AccessToken
    {
        private static AccessToken _instance;
        public string Data { get; set; }
        
        private AccessToken()
        {

        }

        public static AccessToken Instance
        {
            get 
            { 
                if(_instance == null)
                {
                    return new AccessToken();
                }
                return _instance;
            }
        }
    }
}
