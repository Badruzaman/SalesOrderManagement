using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SalesOderManagement.Web.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly HttpClient _httpClient;
        public BuildingService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<DTOBuilding>> GetBuildings()
        {
            try
            {
                var buildling = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOBuilding>>("api/Building/GetAll");
                return buildling;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DTOBuilding?> GetBuildingById(int id)
        {
            var state = await this._httpClient.GetFromJsonAsync<DTOBuilding>("api/Building/GetById?id=" + id);
            return state;
        }
        public async Task<bool> Create(DTOBuilding model)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync("api/Building/Create", model);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Update(DTOBuilding model)
        {
            try
            {
                var response = await this._httpClient.PutAsJsonAsync("api/Building/Update", model);
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
