using App.DTOs;
using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client_Interface
{
    public interface ICategoryClient
    {
        public IEnumerable<CategoryDto>? GetAll();
    }
}
