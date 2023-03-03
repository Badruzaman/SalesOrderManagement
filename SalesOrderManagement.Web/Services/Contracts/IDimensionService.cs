using SalesOrderManagement.Models.DTOs;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface IDimensionService
    {
        Task<IEnumerable<DTODimension>> GetDimensions();
        Task<bool> Create(DTODimension model);
        Task<DTODimension?> GetDimensionById(int id);
        Task<bool> Update(DTODimension model);
    }
}
