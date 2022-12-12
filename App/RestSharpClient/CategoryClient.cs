using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.DTOs;
using App.Client_Interface;

namespace App.RestSharpClient
{
    public class CategoryClient : ICategoryClient
    {
        RestClient _client;
        public CategoryClient(string restUrl) => _client = new RestClient(restUrl);

        public IEnumerable<CategoryDto>? GetAll()
        {
            return _client.Get<IEnumerable<CategoryDto>>(new RestRequest());
        }
    }
}
