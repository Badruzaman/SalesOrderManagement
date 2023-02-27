using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories
{
    public class DimensionRepository : IDimensionRepository
    {
        private readonly SalesOrderDBContext _dbContext;
        public DimensionRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DTODimension?> GetDimensionById(int id)
        {
            try
            {   //exception generate
                //object m = null;
                //string s = m.ToString();
                var dimension = await this._dbContext.Dimension.FindAsync(id);
                if (dimension != null)
                {
                    var DTODimension = new DTODimension() { DimensionId = dimension.DimensionId, Width = dimension.Width, Height = dimension.Height };
                    return DTODimension;
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
                await _dbContext.Dimension.AddAsync(dimension);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(DTODimension model)
        {
            try
            {
                var dimension = await this._dbContext.Dimension.FindAsync(model.DimensionId);
                if (dimension != null)
                {
                    dimension.Width = model.Width;
                    dimension.Height = model.Height;
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
