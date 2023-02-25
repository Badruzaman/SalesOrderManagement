using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOSalesOrder>>> GetSalesOrders()
        {
            try
            {
                //var buildings = await this.GetSalesOrders.GetBuildings();
                //if (buildings == null)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    return Ok(buildings);
                //}
                return Ok(new DTOSalesOrder());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
