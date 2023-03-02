﻿using SalesOrderManagement.Models.DTOs;

namespace SalesOderManagement.Web.Services.Contracts
{
    public interface ISalesOrderService
    {
       

        Task<IEnumerable<DTOSalesOrder>> GetSalesOrders();
        Task Create(DTOSalesOrder model);
        Task<DTOSalesOrder?> GetSalesOrderById(long id);
        Task Update(DTOSalesOrder model);
       
    }   
}
