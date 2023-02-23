using SalesOrderManagement.Api.Entities;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetStates();
        Task<State> GetStateById(int id);
    }
}
