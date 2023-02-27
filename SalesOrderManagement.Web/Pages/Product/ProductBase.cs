using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.Product
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        public IBuildingService BuildingService { get; set; }
        public IEnumerable<DTOBuilding> Buildings { get; set; }
        public DTOBuilding building { get; set; } = new DTOBuilding();
    }
}
