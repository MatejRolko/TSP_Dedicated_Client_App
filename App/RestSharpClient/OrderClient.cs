using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using App.DTOs;
using App.Client_Interface;

namespace App.RestSharpClient
{
    public class OrderClient : IOrderClient
    {
        RestClient _client;
        public OrderClient(string restUrl) => _client = new RestClient(restUrl);
       
        public IEnumerable<OrderDto> GetAll()
        {
            return _client.Get<IEnumerable<OrderDto>>(new RestRequest());
        }

        public OrderDto GetById(int id)
        {
            var request = new RestRequest($"{id}");
            return _client.Get<OrderDto?>(request);
        }
    }
}
