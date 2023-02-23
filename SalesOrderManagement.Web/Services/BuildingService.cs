using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.Dtos;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Create(DTOBuilding model)
        {
            try
            {
                await this._httpClient.PostAsJsonAsync("api/Create", model);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
