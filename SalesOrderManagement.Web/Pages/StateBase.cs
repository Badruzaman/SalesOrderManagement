using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.Dtos;
using System.Xml.Linq;

namespace SalesOrderManagement.Web.Pages
{
    public class StateBase : ComponentBase
    {
        [Inject]
        public IStateService StateService { get; set; }
        public IEnumerable<DTOState> States { get; set; }
        public string name { get; set; }
        protected override async Task OnInitializedAsync()
        {
            States = await StateService.GetStates();
        }
        public async Task addItem()
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var building = new DTOState { Name = name.Trim() };
                await StateService.Create(building);
                this.name = string.Empty;
                States = await StateService.GetStates();
            }
        }
    }
}
