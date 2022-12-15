using App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client_Interface
{
    public interface IProductClient
    {
        public ProductDto? GetById(int id);
        public IEnumerable<ProductDto>? GetAll();
        public int Create(ProductDto product);
        public bool Update(ProductDto product);
        public bool Delete(int id);
    }
}
