using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.Api.Entities
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            this.SalesOrderItems = new HashSet<SalesOrderItems>();
        }
        public int SalesOrderId { get; set; }
        public int BuildingId { get; set; }
        public int StateId { get; set; }
        public virtual Building Building { get; set; }
        public virtual State State { get; set; }
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

        [StringLength(100)]
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual ICollection<SalesOrderItemDetails> SalesOrderItemDetails { get; set; }
    }
    public class SalesOrderItemDetails
    {
        public int SalesOrderItemDetailsId { get; set; }
        public int SalesOrderItemsId { get; set; }
        public int Element { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        public int DimensionId { get; set; }
        public virtual Dimension Dimension { get; set; }
        public virtual SalesOrderItems SalesOrderItems { get; set; }
    }
}
