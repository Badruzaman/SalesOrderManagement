using SalesOrderManagement.Models.DTOs;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface IBuildingService
    {
        Task<IEnumerable<DTOBuilding>> GetBuildings();
        Task<DTOBuilding?> GetBuildingById(int id);
        Task<bool> Create(DTOBuilding model);
        Task<bool> Update(DTOBuilding model);
    }
}
