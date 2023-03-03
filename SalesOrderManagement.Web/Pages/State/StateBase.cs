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
        public IStateService StateService { get; set; }
        public IEnumerable<DTOState> States { get; set; }
        public DTOState state { get; set; } = new DTOState();
        protected string message = string.Empty;
    }
}
