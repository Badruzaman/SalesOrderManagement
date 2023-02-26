using SalesOrderManagement.Models.DTOs;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface IStateService
    {
        Task<IEnumerable<DTOState>> GetStates();
        Task Create(DTOState model);
        Task<DTOState?> GetStateById(int id);
        Task Update(DTOState model);
    }   
}
