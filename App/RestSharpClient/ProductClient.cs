using RestSharp;
using App.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using App.Client_Interface;

namespace App.RestSharpClient
{
    public class ProductClient : IProductClient
    {

        RestClient _client;
        public ProductClient(string restUrl) => _client = new RestClient(restUrl);

        public ProductDto? GetById(int id)
        {
            var request = new RestRequest($"{id}");
            return _client.Get<ProductDto>(request);
        }

        public IEnumerable<ProductDto>? GetAll()
        {
            return _client.Get<IEnumerable<ProductDto>>(new RestRequest());
        }

        public int Create(ProductDto productDto)
        {
            var request = new RestRequest();
            request.AddBody(productDto);
            return _client.Post<int>(request);
        }

        public bool Update(ProductDto productDto)
        {
            var request = new RestRequest($"{productDto.Id}");
            request.AddBody(productDto);
            return _client.Put<bool>(request);
        }

        public bool Delete(int id)
        {
            var request = new RestRequest($"{id}");

            var deleted = _client.Delete<bool>(request);
            if (deleted)
                return true;
            else
                return false;
        }
    }
}
