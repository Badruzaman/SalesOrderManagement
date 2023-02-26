using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.Building
{
    public class BuildingBase : ComponentBase
    {
        [Inject]
        public IBuildingService BuildingService { get; set; }
        public IEnumerable<DTOBuilding> Buildings { get; set; }
        public DTOBuilding building { get; set; } = new DTOBuilding();
        public IStateService StateService { get; set; }
        public IEnumerable<DTOState> States { get; set; }
        public int StateId { get; set; }

    }
}
