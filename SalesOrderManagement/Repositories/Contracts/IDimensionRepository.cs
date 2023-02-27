using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IDimensionRepository
    {
        Task<IEnumerable<Dimension>> GetDimensions();
        Task<DTODimension?> GetDimensionById(int id);
        Task<bool> Create(DTODimension model);
        Task<bool> Update(DTODimension model);
    }
}
