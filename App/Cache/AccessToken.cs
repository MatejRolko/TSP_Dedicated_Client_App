

namespace App.Cache
{
    sealed class AccessToken
    {
        private static AccessToken _instance;
        protected static readonly Object codelock = new ();
        public String Data { get; set; }
        
        private AccessToken()
        {
            Data = "";
        }

        public static AccessToken Instance
        {
            get 
            {
                lock (codelock)
                {
                    if (_instance == null)
                    {
                        return new AccessToken();
                    }
                    return _instance;
                }
            }
        }
    }
}
