using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.SalesOrder
{
    public class SalesOrderBase : ComponentBase
    {
        [Inject]
        protected ISalesOrderService SalesOrderService { get; set; } = new SalesOrderService(new HttpClient());
        [Inject]
        protected IStateService StateService { get; set; } = new StateService(new HttpClient());
        [Inject]
        protected IBuildingService BuildingService { get; set; } = new BuildingService(new HttpClient());
        [Inject]
        protected IProductService ProductService { get; set; } = new ProductService(new HttpClient());
        protected DTOSalesOrder salesOrder { get; set; } = new DTOSalesOrder();
        protected int AttributeTypeId { get; set; }
        protected IEnumerable<DTOSalesOrder> SalesOrders { get; set; } = Enumerable.Empty<DTOSalesOrder>();
        protected IEnumerable<DTOState> States { get; set; } = Enumerable.Empty<DTOState>();
        protected IEnumerable<DTOBuilding> Buildings { get; set; } = Enumerable.Empty<DTOBuilding>();
        protected IEnumerable<DTOProduct> Products { get; set; } = Enumerable.Empty<DTOProduct>();
        protected IEnumerable<DTOProductAttribute> ProductAttributes { get; set; } = Enumerable.Empty<DTOProductAttribute>();

    }
    public class AttributeType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

}
