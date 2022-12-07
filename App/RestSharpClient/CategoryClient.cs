using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.DTOs;

namespace App.RestSharpClient
{
    public class CategoryClient
    {
        RestClient _client;
        public CategoryClient(string restUrl) => _client = new RestClient(restUrl);

        public IEnumerable<CategoryDto>? GetAll()
        {
            return _client.Get<IEnumerable<CategoryDto>>(new RestRequest());
        }
    }
}
