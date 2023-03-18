using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.Api.Entities
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            this.SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }
        public long SalesOrderId { get; set; }
        public int BuildingsId { get; set; }
        public virtual Building Buildings { get; set; }
        public int StatesId { get; set; }
        public virtual State States { get; set; }
        [StringLength(12)]
        public string Code { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
    public class SalesOrderDetail
    {
        public long SalesOrderDetailId { get; set; }
        public long SalesOrderId { get; set; }
        public int ProductAttributeId { get; set; }
        public decimal QuantityOfWindows { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
