using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories.Contracts
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<DTOSalesOrder>> GetSalesOrders();
        Task<DTOSalesOrder?> GetSalesOrderById(int id);
        Task<bool> Create(DTOSalesOrder model);
        Task<bool> Update(DTOSalesOrder model);
    }
}
