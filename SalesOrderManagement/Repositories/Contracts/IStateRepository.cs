using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetStates();
        Task<State> GetStateById(int id);
        Task<bool> Create(DTOState model);
    }
}
