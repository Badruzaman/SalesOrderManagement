using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Api.Repositories
{
    public class DimensionRepository : IDimensionRepository
    {
        private readonly SalesOrderDBContext _dbContext;
        public DimensionRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Dimension> GetDimensionById(int id)
        {
            var Dimension = await this._dbContext.Dimension.FindAsync(id);
            return Dimension;
        }

        public async Task<IEnumerable<Dimension>> GetDimensions()
        {
            var dimensions = await this._dbContext.Dimension.ToListAsync();
            return dimensions;
        }
        public async Task<bool> Create(DTODimension model)
        {
            try
            {
                var dimension = new Dimension { Width = model.Width, Height = model.Height };
                _dbContext.Dimension.Add(dimension);
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
