using App.DTOs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client_Interface
{
    public interface IOrderClient
    {
        public IEnumerable<OrderDto> GetAll();

        public OrderDto GetById(int id);
    }
}
