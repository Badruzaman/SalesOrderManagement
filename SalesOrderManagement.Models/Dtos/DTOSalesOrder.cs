using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Models.DTOs
{
    public class DTOSalesOrder
    {
        public DTOSalesOrder()
        {
            this.DTOSalesOrderDetails = new List<DTOSalesOrderDetail?>();
        }
        public long SalesOrderId { get; set; }
        public int BuildingsId { get; set; }
        public DTOBuilding? Building { get; set; }
        public int StatesId { get; set; }
        public DTOState? State  { get; set; }
        public string? StateName  { get; set; }
        public string? BuildingName  { get; set; }
        public List<DTOSalesOrderDetail?> DTOSalesOrderDetails { get; set; }
    }
    public class DTOSalesOrderDetail
    {
        public long SalesOrderDetailId { get; set; }
        public long SalesOrderId { get; set; }
        public int ProductAttributeId { get; set; }
        public decimal QuantityOfWindows { get; set; }
        public string? ProductAttributeName { get; set; }
        public string? ProductName { get; set; }
    }
}
