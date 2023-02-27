using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Models.DTOs
{
    public class DTOProduct
    {
        public DTOProduct()
        {
            this.productAttributes = new List<ProductAttribute>();
        }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public List<ProductAttribute> productAttributes { get; set; }
    }
    public class ProductAttribute
    {
        public int ProductAttributeId { get; set; }
        public string? ProductAttributeType { get; set; }
        public int DimensionId { get; set; }
        public int ProductId { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
    }
}
