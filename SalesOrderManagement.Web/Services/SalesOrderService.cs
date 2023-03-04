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
        public async Task<bool> Create(DTOSalesOrder model)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync("api/SalesOrder", model);
                if (response.StatusCode.ToString().Equals("OK"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public async Task<DTOSalesOrder?> GetSalesOrderById(long id)
        {
            try
            {
                var SalesOrder = await this._httpClient.GetFromJsonAsync<DTOSalesOrder>("api/SalesOrder/GetSalesOrderById?id=" + id);
                return SalesOrder;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public async Task<bool> Update(DTOSalesOrder model)
        {
            try
            {
               var response = await this._httpClient.PutAsJsonAsync("api/SalesOrder", model);
                if (response.StatusCode.ToString().Equals("OK"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                var response = await this._httpClient.DeleteAsync($"api/SalesOrder?id={id}");
                var result = response.Content.ReadFromJsonAsync<bool>();
                if (result.Result)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
