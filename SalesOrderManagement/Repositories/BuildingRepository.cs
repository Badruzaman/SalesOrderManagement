using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly SalesOrderDBContext _dbContext;
        public BuildingRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DTOBuilding?> GetBuildingById(int id)
        {
            try
            {
                var building = await this._dbContext.Building.FindAsync(id);
                if (building != null)
                {
                    var DTOBuilding = new DTOBuilding() { BuildingId = building.BuildingId, Name = building.Name };
                    return DTOBuilding;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
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
                await _dbContext.Building.AddAsync(building);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(DTOBuilding model)
        {
            try
            {
                var building = await this._dbContext.Building.FindAsync(model.BuildingId);
                if (building != null)
                {
                    building.Name = model.Name;
                    building.StateId = model.StateId;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
