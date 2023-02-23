using SalesOrderManagement.Models.Dtos;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface IStateService
    {
        Task<IEnumerable<DTOState>> GetStates();
    }
}
