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

        [Inject]
        public IStateService StateService { get; set; }
        protected IEnumerable<DTOState> States { get; set; }

    }
}
