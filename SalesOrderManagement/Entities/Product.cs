namespace SalesOrderManagement.Api.Entities
{
    public class Product
    {
        public Product()
        {
            this.ProductAttribute = new HashSet<ProductAttribute>();
            this.Glasses = new HashSet<Glass>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttribute { get; set; }
        public virtual ICollection<Glass> Glasses { get; set; }

    }

}
