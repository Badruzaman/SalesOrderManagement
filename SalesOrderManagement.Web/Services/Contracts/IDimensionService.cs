using SalesOrderManagement.Models.Dtos;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface IDimensionService
    {
        Task<IEnumerable<DTODimension>> GetDimensions();
    }
}
