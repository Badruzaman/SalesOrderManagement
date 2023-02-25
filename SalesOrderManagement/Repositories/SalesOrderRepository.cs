using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories
{
    public class SalesOrderRepository : ISalesOrder
    {

        private readonly SalesOrderDBContext _dbContext;
  
        public SalesOrderRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<DTOBuilding>> GetSalesOrder()
        {
            throw new NotImplementedException();
        }
    }
}
