using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.Product
{
    public class SalesOrderBase : ComponentBase
    {
        [Inject]
        protected IProductService ProductService { get; set; }
        protected IEnumerable<DTOProduct> Products { get; set; }
        [Inject]
        protected IDimensionService DimensionService { get; set; }
        protected IEnumerable<DTODimension> Dimensions { get; set; }
        protected DTOProduct product { get; set; } = new DTOProduct();
        protected int AttributeTypeId { get; set; }
    }
    public class AttributeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
