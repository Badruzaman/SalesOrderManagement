using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SalesOderManagement.Web.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly HttpClient _httpClient;
        public SalesOrderService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<DTOSalesOrder>> GetSalesOrders()
        {
            try
            {
                var SalesOrders = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOSalesOrder>>("api/SalesOrder");
                return SalesOrders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Create(DTOSalesOrder model)
        {
            await this._httpClient.PostAsJsonAsync("api/SalesOrder", model);
        }
        public async Task<DTOSalesOrder?> GetSalesOrderById(long id)
        {
            var SalesOrder = await this._httpClient.GetFromJsonAsync<DTOSalesOrder>("api/SalesOrder/GetSalesOrderById?id=" + id);
            return SalesOrder;
        }
        public async Task Update(DTOSalesOrder model)
        {
           await this._httpClient.PutAsJsonAsync("api/SalesOrder", model);
        }
    }
}
