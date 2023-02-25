using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.Dtos;
using System.Xml.Linq;

namespace SalesOrderManagement.Web.Pages
{
    public class DimensionBase: ComponentBase
    {
        [Inject]
        public IDimensionService DimensionService { get; set; }
        public IEnumerable<DTODimension> Dimensions { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Dimensions = await DimensionService.GetDimensions();
        }
        public async Task addItem()
        {
            if (!string.IsNullOrWhiteSpace(width) && !string.IsNullOrWhiteSpace(height))
            {
                var dimension = new DTODimension { Width = width.Trim() , Height = height.Trim()};
                await DimensionService.Create(dimension);
                this.width = string.Empty;
                this.height = string.Empty;
                Dimensions = await DimensionService.GetDimensions();
            }
        }
    }
}
