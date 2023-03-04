using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Api.Data;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;
using System;

namespace SalesOrderManagement.Api.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {

        private readonly Random _random = new Random();
        private readonly SalesOrderDBContext _dbContext;

        public SalesOrderRepository(SalesOrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DTOSalesOrder?> GetSalesOrderById(long id)
        {
            try
            {
                var dTOSalesOrder = await (from saleorder in _dbContext.SalesOrder
                                           join salesOrderDetail in _dbContext.SalesOrder
                                           on saleorder.SalesOrderId equals salesOrderDetail.SalesOrderId
                                           where saleorder.SalesOrderId == id
                                           select new DTOSalesOrder
                                           {
                                               SalesOrderId = saleorder.SalesOrderId,
                                               BuildingsId = saleorder.BuildingsId,
                                               StatesId = saleorder.StatesId,
                                               Code = saleorder.Code,
                                               DTOSalesOrderDetails = saleorder.SalesOrderDetail.Select(_it => new DTOSalesOrderDetail
                                               {
                                                   SalesOrderDetailId = _it.SalesOrderDetailId,
                                                   ProductAttributeId = _it.ProductAttributeId,
                                                   SalesOrderId = _it.SalesOrderId,
                                                   QuantityOfWindows = _it.QuantityOfWindows,
                                               }).ToList()
                                           }).FirstOrDefaultAsync();
                return dTOSalesOrder;
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
                var dTOSalesOrders = await this._dbContext.SalesOrder
                .Include(it => it.Buildings)
                .Include(it => it.States)
                .Select(it => new DTOSalesOrder
                {
                    SalesOrderId = it.SalesOrderId,
                    BuildingsId = it.BuildingsId,
                    StatesId = it.StatesId,
                    StateName = it.States.Name,
                    BuildingName = it.Buildings.Name,
                    Code = it.Code
                }).ToListAsync();
                return dTOSalesOrders;
            }
            catch (Exception)
            {
                return null;
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
                var code = "SO-" + Generate();
                salesOrder.Code = code;
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
                List<long> deletedIds = new List<long>();
                var salesOrder = await this._dbContext.SalesOrder.Where(it => it.SalesOrderId == model.SalesOrderId).Include(_it => _it.SalesOrderDetail).FirstOrDefaultAsync();
                if (salesOrder != null)
                {
                    foreach (var item in salesOrder.SalesOrderDetail)
                    {
                        deletedIds.Add(item.SalesOrderDetailId);
                    }
                    salesOrder.StatesId = model.StatesId;
                    salesOrder.BuildingsId = model.BuildingsId;
                    foreach (var _item in model.DTOSalesOrderDetails)
                    {
                        if (_item.SalesOrderDetailId == 0)
                        {
                            salesOrder.SalesOrderDetail.Add(new SalesOrderDetail() { ProductAttributeId = _item.ProductAttributeId, QuantityOfWindows = _item.QuantityOfWindows });
                        }
                        else
                        {
                            var updateModel = salesOrder.SalesOrderDetail.FirstOrDefault(_it => _it.SalesOrderDetailId == _item.SalesOrderDetailId);
                            if (updateModel != null)
                            {
                                updateModel.ProductAttributeId = _item.ProductAttributeId;
                                updateModel.QuantityOfWindows = _item.QuantityOfWindows;
                                deletedIds.Remove(_item.SalesOrderDetailId);
                            }
                        }
                    }
                    foreach (var id in deletedIds)
                    {
                        var deletedModel = salesOrder.SalesOrderDetail.FirstOrDefault(_it => _it.SalesOrderDetailId.Equals(id));
                        if (deletedModel != null)
                        {
                            salesOrder.SalesOrderDetail.Remove(deletedModel);
                        }
                    }
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
        public async Task<bool> Delete(long id)
        {
            try
            {
                var salesOrder = await this._dbContext.SalesOrder.Where(it => it.SalesOrderId == id).FirstOrDefaultAsync();
                if (salesOrder != null)
                {
                    var deletedModel = _dbContext.SalesOrder.Remove(salesOrder);
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
        private string Generate()
        {
            const string chars = "0123456789";
            var salesOrderCode = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[_random.Next(s.Length)])
                .ToArray());

            return salesOrderCode;
        }
    }
}
