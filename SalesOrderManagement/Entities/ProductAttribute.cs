namespace SalesOrderManagement.Api.Entities
{
    public class ProductAttribute
    {
        public int ProductAttributeId { get; set; }
        public string ProductAttributeType { get; set; }
        public int DimensionId { get; set; }
        public int ProductId { get; set; }
        public virtual Dimension Dimension { get; set; }
        public virtual Product Product { get; set; }
    }
}
