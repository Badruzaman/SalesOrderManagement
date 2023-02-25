using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Threading.Tasks;

namespace SalesOrderManagement.Web.Pages
{
    public class BuildingBase : ComponentBase
    {
        [Inject]
        public IBuildingService BuildingService { get; set; }
        public IEnumerable<DTOBuilding> Buildings { get; set; }
        public string name { get; set; }
        public IStateService StateService { get; set; }
        public IEnumerable<DTOState> States { get; set; }
        public int stateId { get; set; }
       
        protected override async Task OnInitializedAsync()
        {
            Buildings = await BuildingService.GetBuildings();
            States = await StateService.GetStates();
        }
        public async Task addItem()
        {
            if (!string.IsNullOrWhiteSpace(name) && stateId > 0)
            {
                var building = new DTOBuilding { Name = name.Trim(),StateId = stateId};
                await BuildingService.Create(building);
                this.name = string.Empty;
                Buildings = await BuildingService.GetBuildings();
            }
        }
    }
}
