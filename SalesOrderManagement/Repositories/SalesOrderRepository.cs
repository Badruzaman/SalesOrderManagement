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

        public async Task<DTOSalesOrder> GetSalesOrderById(long id)
        {
            try
            {
                var salesOrder = await this._dbContext.SalesOrder.FindAsync(id);
                if (salesOrder == null)
                {
                    return null;
                }
                var DTOSalesOrder = new DTOSalesOrder { SalesOrderId = salesOrder.SalesOrderId, BuildingsId = salesOrder.BuildingsId, StatesId = salesOrder.StatesId };
                return DTOSalesOrder;
                //var DtoSalesOrder = await this._dbContext.SalesOrder.FindAsync(id);
                //DtoSalesOrder.Select(it => new DTOSalesOrder
                //{
                //    SalesOrderId = it.SalesOrderId,
                //    BuildingsId = it.BuildingsId,
                //    StatesId = it.StatesId,
                //    StateName = it.States.Name,
                //    BuildingName = it.Buildings.Name,
                //    DTOSalesOrderDetails = it.SalesOrderDetail.Select(_it => new DTOSalesOrderDetail
                //    {
                //        SalesOrderDetailId = _it.SalesOrderDetailId,
                //        SalesOrderId = _it.SalesOrderId,
                //        ProductAttributeId = _it.ProductAttributeId,
                //        QuantityOfWindows = _it.QuantityOfWindows,
                //        ProductAttributeName = _it.ProductAttribute.Product.ProductName + " " + _it.ProductAttribute.ProductAttributeType + " " + _it.ProductAttribute.Dimension.Width + " X " + _it.ProductAttribute.Dimension.Height
                //    }).ToList()
                //});
                //return DtoSalesOrder;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<IEnumerable<DTOSalesOrder>> GetSalesOrders()
        {
            try
            {
                var DTOSalesOrders = await this._dbContext.SalesOrder.Include(it => it.Buildings).Include(it => it.States)
                .Select(it => new DTOSalesOrder
                {
                    SalesOrderId = it.SalesOrderId,
                    BuildingsId = it.BuildingsId,
                    StatesId = it.StatesId,
                    StateName = it.States.Name,
                    BuildingName = it.Buildings.Name,
                    DTOSalesOrderDetails = it.SalesOrderDetail.Select(_it => new DTOSalesOrderDetail
                    {
                        SalesOrderDetailId = _it.SalesOrderDetailId,
                        SalesOrderId = _it.SalesOrderId,
                        ProductAttributeId = _it.ProductAttributeId,
                        QuantityOfWindows = _it.QuantityOfWindows,
                        ProductAttributeName = _it.ProductAttribute.Product.ProductName + " " + _it.ProductAttribute.ProductAttributeType + " " + _it.ProductAttribute.Dimension.Width + " X " + _it.ProductAttribute.Dimension.Height
                    }).ToList()
                }).ToListAsync();
                return DTOSalesOrders;
            }
            catch (Exception)
            {
                return Enumerable.Empty<DTOSalesOrder>();
            }
        }
        
        public async Task<bool> Create(DTOSalesOrder model)
        {
            try
            {
                var salesOrder = new SalesOrder() { BuildingsId = model.BuildingsId, StatesId = model.StatesId };
                foreach (var attribute in model.DTOSalesOrderDetails)
                {
                    var _attribute = new SalesOrderDetail() { ProductAttributeId = attribute.ProductAttributeId, QuantityOfWindows = attribute.QuantityOfWindows };
                    salesOrder.SalesOrderDetail.Add(_attribute);
                }
                await _dbContext.SalesOrder.AddAsync(salesOrder);
                await _dbContext.SaveChangesAsync();
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
                var salesOrder = await this._dbContext.SalesOrder.FindAsync(model.SalesOrderId);
                if (salesOrder != null)
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
