using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Web.Pages
{
    public class StateBase : ComponentBase
    {
        [Inject]
        public IStateService StateService { get; set; }
        public IEnumerable<DTOState> States { get; set; }

        protected override async Task OnInitializedAsync()
        {
            States = await StateService.GetStates();
        }
    }
}
