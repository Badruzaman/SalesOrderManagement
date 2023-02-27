using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;


namespace SalesOrderManagement.Web.Pages.Dimension
{
    public class DimensionBase : ComponentBase
    {
        [Inject]
        public IDimensionService DimensionService { get; set; }
        public IEnumerable<DTODimension> Dimensions { get; set; }
        public DTODimension dimension { get; set; } = new DTODimension();
        
    }
}
