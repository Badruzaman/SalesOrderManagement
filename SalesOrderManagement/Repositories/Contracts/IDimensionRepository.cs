using SalesOrderManagement.Api.Entities;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IDimensionRepository
    {
        Task<IEnumerable<Dimension>> GetDimensions();
        Task<Dimension> GetDimensionById(int id);
    }
}
