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
            this.DTOProductAttributes = new List<DTOProductAttribute>();
        }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public List<DTOProductAttribute> DTOProductAttributes { get; set; }
    }
    public class DTOProductAttribute
    {
        public int ProductAttributeId { get; set; }
        public string? ProductAttributeType { get; set; }
        public int DimensionId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        public string? Width { get; set; }
        public string? Height { get; set; }
        public DTODimension? DTODimension { get; set; }
        public string? ActualDimension { get; set; }
        public string? ProductAttributeName { get; set; }
    }
                   
}
