using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.ComponentModel.DataAnnotations;


namespace SalesOrderManagement.Web.Pages.State
{
    public class StateBase : ComponentBase
    {
        [Inject]
        protected IStateService StateService { get; set; }
        protected IEnumerable<DTOState> States { get; set; } = new List<DTOState>();
        protected DTOState state { get; set; } = new DTOState();
        protected string message = string.Empty;
    }
}
