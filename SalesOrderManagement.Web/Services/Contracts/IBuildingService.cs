using SalesOrderManagement.Models.Dtos;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface IBuildingService
    {
        Task<IEnumerable<DTOBuilding>> GetBuildings();
        Task<bool> Create(DTOBuilding model);
    }
}
