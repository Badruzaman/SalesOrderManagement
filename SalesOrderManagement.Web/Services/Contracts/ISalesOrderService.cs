using SalesOrderManagement.Models.DTOs;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface ISalesOrderService
    {
       
        Task<IEnumerable<DTOSalesOrder>> GetSalesOrders();
        Task<bool> Create(DTOSalesOrder model);
        Task<DTOSalesOrder?> GetSalesOrderById(long id);
        Task<bool> Update(DTOSalesOrder model);
        Task<bool> Delete(long id);
    }   
}
