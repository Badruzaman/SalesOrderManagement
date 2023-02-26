using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface IStateRepository
    {
        Task<IEnumerable<DTOState>> GetStates();
        Task<DTOState?> GetStateById(int id);
        Task<bool> Create(DTOState model);
        Task<bool> Update(DTOState model);
    }
}
