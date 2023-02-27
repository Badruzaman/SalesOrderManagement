using Microsoft.AspNetCore.Components;
using SalesOderManagement.Web.Services.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Web.Pages.Building
{
    public class BuildingBase : ComponentBase
    {
        [Inject]
        public IEnumerable<DTOBuilding> Buildings { get; set; }
       
    }
}
