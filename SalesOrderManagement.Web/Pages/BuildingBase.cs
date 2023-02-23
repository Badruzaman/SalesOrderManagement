using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Web.Pages
{
    public class BuildingBase : ComponentBase  
    {
        [Inject]
        public IBuildingService BuildingService { get; set; }
        public IEnumerable<DTOBuilding> Buildings { get; set; }
        public string name { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Buildings = await BuildingService.GetBuildings();
        }
        public async Task addItem()
        {
            var building = new DTOBuilding { Name = name };
            await BuildingService.Create(building);
        }
    }
}
