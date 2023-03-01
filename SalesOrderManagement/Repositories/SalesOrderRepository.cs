using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {

        private readonly SalesOrderDBContext _dbContext;
  
        public SalesOrderRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DTOSalesOrder?> GetSalesOrderById(int id)
        {
            var SalesOrder = await this._dbContext.SalesOrder.FindAsync(id);
            if (SalesOrder == null)
            {
                return null;
            }
            var DTOSalesOrder = new DTOSalesOrder { SalesOrderId = SalesOrder.SalesOrderId};
            return DTOSalesOrder;
        }
        public async Task<IEnumerable<DTOSalesOrder>> GetSalesOrders()
        {
            var DTOSalesOrders = await this._dbContext.SalesOrder
            .Select(it => new DTOSalesOrder
            {
                SalesOrderId = it.SalesOrderId,
                //SalesOrderName = it.SalesOrderName,
                //DTOSalesOrderAttributes = it.SalesOrderAttribute.Select(_it => new DTOSalesOrderAttribute
                //{
                //    SalesOrderAttributeId = _it.SalesOrderAttributeId,
                //    SalesOrderAttributeType = _it.SalesOrderAttributeType,
                //    DimensionId = _it.DimensionId,
                //    ActualDimension = _it.Dimension.Width + " X " + _it.Dimension.Height
                //}).ToList()
            }).ToListAsync();
            return DTOSalesOrders;
        }
        public async Task<bool> Create(DTOSalesOrder model)
        {
            try
            {
                var SalesOrder = new SalesOrder() {};
                foreach (var attribute in model.DTOSalesOrderDetails)
                {
                    var _attribute = new SalesOrderDetail() {  };
                    SalesOrder.SalesOrderDetail.Add(_attribute);
                }
                await _dbContext.SalesOrder.AddAsync(SalesOrder);
                var result = await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(DTOSalesOrder model)
        {
            try
            {
                var SalesOrder = await this._dbContext.SalesOrder.FindAsync(model.SalesOrderId);
                if (SalesOrder != null)
                {
                    //SalesOrder.SalesOrderName = model.SalesOrderName;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
