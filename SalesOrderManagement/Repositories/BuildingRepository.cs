using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Api.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly SalesOrderDBContext _dbContext;
        public BuildingRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Building> GetBuildingById(int id)
        {
            var building = await this._dbContext.Building.FindAsync(id);
            return building;
        }

        public async Task<IEnumerable<DTOBuilding>> GetBuildings()
        {
            var buildings = await this._dbContext.Building.ToListAsync();
            var DTObuilding = from build in buildings select new DTOBuilding { BuildingId = build.BuildingId, Name = build.Name };
            return DTObuilding;
        }

        public async Task<bool> Create(DTOBuilding model)
        {
            try
            {
                var building = new Building { Name = model.Name, StateId = model.StateId };
                _dbContext.Building.Add(building);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
