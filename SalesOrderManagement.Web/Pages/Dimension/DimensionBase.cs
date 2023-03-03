using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;


namespace SalesOrderManagement.Web.Pages.Dimension
{
    public class DimensionBase : ComponentBase
    {
        [Inject]
        protected IDimensionService DimensionService { get; set; }
        protected IEnumerable<DTODimension> Dimensions { get; set; }
        protected DTODimension dimension { get; set; } = new DTODimension();
        protected string message = string.Empty;
    }

}