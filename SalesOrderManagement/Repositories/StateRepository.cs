using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly SalesOrderDBContext _dbContext;
        public StateRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DTOState?> GetStateById(int id)
        {
            var state = await this._dbContext.State.FindAsync(id);
            if (state == null)
            {
                return null;
            }
            var DTOState = new DTOState { StateId = state.StateId, Name = state.Name };
            return DTOState;
        }
        public async Task<IEnumerable<DTOState>> GetStates()
        {
            var states = await this._dbContext.State.ToListAsync();
            var DTOState = from state in states select new DTOState { StateId = state.StateId, Name = state.Name };
            return DTOState;
        }
        public async Task<bool> Create(DTOState model)
        {
            try
            {
                var state = new State { Name = model.Name };
                await _dbContext.State.AddAsync(state);
                var result = await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(DTOState model)
        {
            try
            {
                var state = await this._dbContext.State.FindAsync(model.StateId);
                if (state != null)
                {
                    state.Name = model.Name;
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
