using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages
{
    public class SalesOrderBase : ComponentBase
    {
        [Inject]
        public IBuildingService BuildingService { get; set; }
        public IStateService StateService { get; set; }
        public IEnumerable<DTOBuilding> Buildings { get; set; }
        public IEnumerable<DTOState> States { get; set; }
        public string windowName { get; set; }
        public string QuantityOfWindow { get; set; }
        public string TotalSubElement { get; set; }  
        protected override async Task OnInitializedAsync()
        {
            Buildings = await BuildingService.GetBuildings();
            //States = await StateService.GetStates();
        }
        public async Task addItem()
        {
            if (!string.IsNullOrWhiteSpace(windowName))
            {
                ////var building = new DTOBuilding { Name = name.Trim()};
                ////await BuildingService.Create(building);
                ////this.name = string.Empty;
                ////Buildings = await BuildingService.GetBuildings();
            }
        }
    }
}
