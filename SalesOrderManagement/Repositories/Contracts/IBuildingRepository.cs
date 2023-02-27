using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<DTOBuilding>> GetBuildings();
        Task<DTOBuilding?> GetBuildingById(int id);
        Task<bool> Create(DTOBuilding model);
        Task<bool> Update(DTOBuilding model);
    }
}
