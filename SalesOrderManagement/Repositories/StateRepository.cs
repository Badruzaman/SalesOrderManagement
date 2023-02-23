using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;

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
    }
}
