using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Net.Http.Headers;
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
                var products = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOProduct>>("api/Product/GetAll");
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Create(DTOProduct model)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync("api/Product/Create", model);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<DTOProduct?> GetProductById(int id)
        {
            var Product = await this._httpClient.GetFromJsonAsync<DTOProduct>("api/Product/GetById?id=" + id);
            return Product;
        }
        public async Task<bool> Update(DTOProduct model)
        {
            try
            {
                var response = await this._httpClient.PutAsJsonAsync("api/Product/Update", model);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<DTOProductAttribute>> GetProductAttributes()
        {
            var productAttributes = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOProductAttribute>>("api/Product/GetAllAttributes");
            return productAttributes;
        }
    }
}
