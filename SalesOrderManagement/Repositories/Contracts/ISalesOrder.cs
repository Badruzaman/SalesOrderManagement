using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface ISalesOrder
    {
        Task<IEnumerable<DTOBuilding>> GetSalesOrder();
    }
}
