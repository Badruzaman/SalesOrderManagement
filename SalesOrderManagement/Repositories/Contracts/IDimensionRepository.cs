using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IDimensionRepository
    {
        Task<IEnumerable<Dimension>> GetDimensions();
        Task<Dimension> GetDimensionById(int id);
        Task<bool> Create(DTODimension model);
    }
}
