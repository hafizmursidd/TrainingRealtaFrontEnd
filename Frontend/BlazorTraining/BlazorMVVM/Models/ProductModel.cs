using BlazorMVVM.DTOs;
using System.Net.Http.Json;

namespace BlazorMVVM.Models
{
    public interface IProductModel
    {
        Task<List<Product>> GetProductsAsync();
    }

    public class ProductDummyModel : IProductModel
    {
        public Task<List<Product>> GetProductsAsync()
        {
            var loRtn = new List<Product>();

            for (int i = 0; i < 3; i++)
            {
                loRtn.Add(new Product
                {
                    ProductID = i,
                    ProductName = $"Product{i}"
                });
            }

            return Task.FromResult(loRtn);
        }
    }

    public class ProductApiModel : IProductModel
    {
        private readonly HttpClient _httpClient;

        public ProductApiModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("sample-data/product.json");
        }
    }
}
