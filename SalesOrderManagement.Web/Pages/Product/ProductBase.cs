using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.Product
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<DTOProduct> Products { get; set; }
        [Inject]
        public IDimensionService DimensionService { get; set; }
        public IEnumerable<DTODimension> Dimensions { get; set; }
        public DTOProduct product { get; set; } = new DTOProduct();
        public int AttributeTypeId { get; set; }
        
    }

    public class AttributeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
