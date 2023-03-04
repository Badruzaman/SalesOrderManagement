using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.Building
{
    public class BuildingBase : ComponentBase
    {
        [Inject]
        protected IBuildingService BuildingService { get; set; }
        protected IEnumerable<DTOBuilding> Buildings { get; set; }
        protected DTOBuilding building { get; set; } = new DTOBuilding();
        
        [Inject]
        protected IStateService StateService { get; set; }
        protected IEnumerable<DTOState> States { get; set; } = new List<DTOState>();
        protected string message = string.Empty;
    }
}
