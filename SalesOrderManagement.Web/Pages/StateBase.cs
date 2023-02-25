using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.Web.Pages
{
    public class StateBase : ComponentBase
    {
        [Inject]

       
        public IStateService StateService { get; set; }
        public IEnumerable<DTOState> States { get; set; }
        public DTOState state { get; set; } = new DTOState();
        protected override async Task OnInitializedAsync()
        {
            state = await StateService.GetStateById(2);
            States = await StateService.GetStates();
        }

        public async Task CreateState()
        {

            if (!string.IsNullOrWhiteSpace(state.Name))
            {
                await StateService.Create(state);
                state.Name = string.Empty;
                States = await StateService.GetStates();
            }
        }
        //public async Task EditState(int id)
        //{
        //    if (state.StateId > 0)
        //    {
        //        state = await StateService.GetStateById(id);
        //    }

        //}
        public async Task UpdateState()
        {

            if (!string.IsNullOrWhiteSpace(state.Name))
            {
                await StateService.Create(state);
                state.Name = string.Empty;
                States = await StateService.GetStates();
            }
        }
        void cancel()
        {
            //navigationManager.NavigateTo("/booklist");
        }
    }
}
