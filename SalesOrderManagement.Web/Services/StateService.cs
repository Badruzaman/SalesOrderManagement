using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Net.Http.Json;

namespace SalesOderManagement.Web.Services
{
    public class StateService : IStateService
    {
        private readonly HttpClient _httpClient;
        public StateService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<DTOState>> GetStates()
        {
            try
            {
                var states = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOState>>("api/State/GetAll");
                return states;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Create(DTOState model)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync("api/State/Create", model);
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
        public async Task<DTOState?> GetStateById(int id)
        {
            var state = await this._httpClient.GetFromJsonAsync<DTOState>("api/State/GetById?id=" + id);
            return state;
        }
        public async Task<bool> Update(DTOState model)
        {
            try
            {
                var response = await this._httpClient.PutAsJsonAsync("api/State/Update", model);
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
    }
}
