using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.Dtos;

namespace SalesOrderManagement.Web.Pages
{
    public class DimensionBase: ComponentBase
    {
        [Inject]
        public IDimensionService DimensionService { get; set; }
        public IEnumerable<DTODimension> Dimensions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Dimensions = await DimensionService.GetDimensions();
        }
    }
}
