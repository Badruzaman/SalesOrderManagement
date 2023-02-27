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
                var buildling = await this._httpClient.GetFromJsonAsync<IEnumerable<DTOBuilding>>("api/Building");
                return buildling;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DTOBuilding?> GetBuildingById(int id)
        {
            var state = await this._httpClient.GetFromJsonAsync<DTOBuilding>("api/Building/GetBuildingById?id=" + id);
            return state;
        }
        public async Task Create(DTOBuilding model)
        {
             await this._httpClient.PostAsJsonAsync("api/Building", model);
        }
        public async Task Update(DTOBuilding model)
        {
            await this._httpClient.PutAsJsonAsync("api/Building", model);
        }
    }
}
