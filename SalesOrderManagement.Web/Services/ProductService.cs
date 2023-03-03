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
                var products = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOProduct>>("api/Product");
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
                var response = await this._httpClient.PostAsJsonAsync("api/Product", model);
                if (response.StatusCode.ToString().Equals("OK"))
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
            var Product = await this._httpClient.GetFromJsonAsync<DTOProduct>("api/Product/GetProductById?id=" + id);
            return Product;
        }
        public async Task<bool> Update(DTOProduct model)
        {
            try
            {
                var response = await this._httpClient.PutAsJsonAsync("api/Product", model);
                if (response.StatusCode.ToString().Equals("OK"))
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
            var ProductAttributes = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOProductAttribute>>("api/Product/GetProductAttributes");
            return ProductAttributes;
        }
    }
}
