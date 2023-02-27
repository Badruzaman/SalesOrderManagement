using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Net.Http.Json;

namespace SalesOderManagement.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<DTOProduct>> GetProducts()
        {
            try
            {
                var products = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOProduct>>("api/Product");
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Create(DTOProduct model)
        {
            await this._httpClient.PostAsJsonAsync("api/Product", model);
        }
        public async Task<DTOProduct?> GetProductById(int id)
        {
            var Product = await this._httpClient.GetFromJsonAsync<DTOProduct>("api/Product/GetProductById?id=" + id);
            return Product;
        }
        public async Task Update(DTOProduct model)
        {
           await this._httpClient.PutAsJsonAsync("api/Product", model);
        }
    }
}
