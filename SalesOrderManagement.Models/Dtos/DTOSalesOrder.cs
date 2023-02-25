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
            this.SalesOrderItems = new HashSet<SalesOrderItems>();
        }
        public int SalesOrderId { get; set; }
        public int BuildingId { get; set; }
        public int StateId { get; set; }
        public string  Building { get; set; }
        public string State  { get; set; }
        public virtual ICollection<SalesOrderItems> SalesOrderItems { get; set; }
    }
    public class SalesOrderItems
    {
        public SalesOrderItems()
        {
            this.SalesOrderItemDetails = new HashSet<SalesOrderItemDetails>();
        }
        public int SalesOrderItemsId { get; set; }
        public int SalesOrderId { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public  DTOSalesOrder SalesOrder { get; set; }
        public  ICollection<SalesOrderItemDetails> SalesOrderItemDetails { get; set; }
    }
    public class SalesOrderItemDetails
    {
        public int SalesOrderItemDetailsId { get; set; }
        public int SalesOrderItemsId { get; set; }
        public int Element { get; set; }
        public string Type { get; set; }
        public int DimensionId { get; set; }
        public string  Dimension { get; set; }
        public  SalesOrderItems SalesOrderItems { get; set; }
    }
}
