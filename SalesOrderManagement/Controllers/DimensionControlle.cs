using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;
namespace SalesOrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionController : ControllerBase
    {
        private readonly IDimensionRepository DimensionRepository;
        public DimensionController(IDimensionRepository DimensionRepository)
        {
            this.DimensionRepository = DimensionRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Dimension>>> GetDimensions()
        {
            try
            {
                var dimensions = await this.DimensionRepository.GetDimensions();
                if (dimensions == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(dimensions);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(DTODimension model)
        {
            try
            {
                var result = await this.DimensionRepository.Create(model);
                if (result)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "error updating data in the database");
            }

        }
        [HttpPut("Update")]
        public async Task<ActionResult<bool>> Update(DTODimension model)
        {
            try
            {
                var result = await this.DimensionRepository.Update(model);
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
        [HttpGet("GetById")]
        public async Task<ActionResult<Dimension>> GetDimensionById(int id)
        {
            try
            {
                var dimension = await this.DimensionRepository.GetDimensionById(id);
                if (dimension == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(dimension);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}

