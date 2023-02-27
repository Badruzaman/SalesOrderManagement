using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.Api.Entities
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            this.SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }
        public int SalesOrderId { get; set; }
        public int BuildingsId { get; set; }
        public virtual Building Buildings { get; set; }
        public int StatesId { get; set; }
        public virtual State States { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
    public class SalesOrderDetail
    {
        public int SalesOrderDetailId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOfWindows { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
