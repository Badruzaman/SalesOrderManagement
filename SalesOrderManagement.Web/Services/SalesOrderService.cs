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
                var salesOrders = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOSalesOrder>>("api/SalesOrder/GetAll");
                return salesOrders;
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
                var response = await this._httpClient.PostAsJsonAsync("api/SalesOrder/Create", model);
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
                var SalesOrder = await this._httpClient.GetFromJsonAsync<DTOSalesOrder>("api/SalesOrder/GetById?id=" + id);
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
               var response = await this._httpClient.PutAsJsonAsync("api/SalesOrder/Update", model);
                if (response.IsSuccessStatusCode)
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
                var response = await this._httpClient.DeleteAsync($"api/SalesOrder/Delete?id={id}");
                if (response.IsSuccessStatusCode)
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
