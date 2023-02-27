using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;
namespace SalesOrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepository BuildingRepository;
        public BuildingController(IBuildingRepository BuildingRepository)
        {
            this.BuildingRepository = BuildingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOBuilding>>> GetBuildings()
        {
            try
            {
                var buildings = await this.BuildingRepository.GetBuildings();
                if (buildings == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(buildings);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(DTOBuilding model)
        {
            try
            {
                var result = await this.BuildingRepository.Create(model);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error storing data in the database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Update(DTOBuilding model)
        {
            try
            {
                var result = await this.BuildingRepository.Update(model);
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

        [HttpGet("GetBuildingById")]
        public async Task<ActionResult<Building>> GetBuildingById(int id)
        {
            try
            {
                var building = await this.BuildingRepository.GetBuildingById(id);
                if (building == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(building);
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

