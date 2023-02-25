using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface ISalesOrder
    {
        Task<IEnumerable<DTOBuilding>> GetSalesOrder();

    }
}
