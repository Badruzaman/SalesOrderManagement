using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.SalesOrder
{
    public class SalesOrderBase : ComponentBase
    {
        [Inject]
        public ISalesOrderService SalesOrderService { get; set; }
        public IEnumerable<DTOSalesOrder> SalesOrders { get; set; }
        [Inject]
        public IDimensionService DimensionService { get; set; }
        public IEnumerable<DTODimension> Dimensions { get; set; }
        public DTOSalesOrder SalesOrder { get; set; } = new DTOSalesOrder();
        public int AttributeTypeId { get; set; }
        
    }

    public class AttributeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
