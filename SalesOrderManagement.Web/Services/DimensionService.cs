using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
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
                var dimensions = await this._httpClient.GetFromJsonAsync<IEnumerable<DTODimension>>("api/Dimension");
                return dimensions;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DTODimension?> GetDimensionById(int id)
        {
            try
            {
                var dimension = await this._httpClient.GetFromJsonAsync<DTODimension>("api/Dimension/GetDimensionById?id=" + id);
                return dimension;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Create(DTODimension model)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync("api/Dimension", model);
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
        public async Task<bool> Update(DTODimension model)
        {
            try
            {
                var response = await this._httpClient.PutAsJsonAsync("api/Dimension", model);
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


    }
}
