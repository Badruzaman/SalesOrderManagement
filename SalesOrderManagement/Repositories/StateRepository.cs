using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Api.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly SalesOrderDBContext _dbContext;
        public StateRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<State> GetStateById(int id)
        {
            var state = await this._dbContext.State.FindAsync(id);
            return state;
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            var states = await this._dbContext.State.ToListAsync();
            return states;
        }
        public async Task<bool> Create(DTOState model)
        {
            try
            {
                var state = new State { Name = model.Name };
                _dbContext.State.Add(state);
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
