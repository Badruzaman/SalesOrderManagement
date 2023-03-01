using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;

namespace SalesOrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderRepository SalesOrderRepository;
        public SalesOrderController(ISalesOrderRepository SalesOrderRepository)
        {
            this.SalesOrderRepository = SalesOrderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOSalesOrder>>> GetSalesOrders()
        {
            try
            {
                var SalesOrders = await this.SalesOrderRepository.GetSalesOrders();
                if (SalesOrders == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(SalesOrders);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(DTOSalesOrder model)
        {
            try
            {
                var result = await this.SalesOrderRepository.Create(model);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error storing data in the database");
            }
        }

        [HttpGet("GetSalesOrderById")]
        public async Task<ActionResult<DTOSalesOrder>> GetSalesOrderById(int id)
        {
            try
            {
                var SalesOrder = await this.SalesOrderRepository.GetSalesOrderById(id);
                if (SalesOrder == null)
                {
                    return NotFound();
                }
                return Ok(SalesOrder);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<HttpResponseMessage>> Update(DTOSalesOrder model)
        {
            try
            {
                var result = await this.SalesOrderRepository.Update(model);
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error storing data in the database");
            }
        }
    }
}
