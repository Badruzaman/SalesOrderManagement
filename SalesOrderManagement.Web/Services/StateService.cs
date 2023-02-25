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
                var state = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOState>>("api/State");
                return state;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Create(DTOState model)
        {
            await this._httpClient.PostAsJsonAsync("api/State", model);
        }
    }
}
