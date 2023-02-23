using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<DTOBuilding>> GetBuildings();
        Task<Building> GetBuildingById(int id);
        Task<bool> Create(DTOBuilding model);

    }
}
