using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.Dtos;
using System.Net.Http.Json;

namespace SalesOderManagement.Web.Services
{
    public class DimensionService : IDimensionService
    {
        private readonly HttpClient _httpClient;
        public DimensionService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }



        public async Task<IEnumerable<DTODimension>> GetDimensions()
        {
            try
            {
                var dimension = await this._httpClient.GetFromJsonAsync<IEnumerable<DTODimension>>("api/Dimension");
                return dimension;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Create(DTODimension model)
        {
            await this._httpClient.PostAsJsonAsync("api/Dimension", model);
        }

    }
}
