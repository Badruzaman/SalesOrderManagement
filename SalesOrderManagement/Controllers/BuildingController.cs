﻿using Microsoft.AspNetCore.Http;
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
        private readonly IBuildingRepository buildingRepository;
        public BuildingController(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOBuilding>>> GetBuildings()
        {
            try
            {
                var buildings = await this.buildingRepository.GetBuildings();
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
                var result = await this.buildingRepository.Create(model);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error storing data in the database");
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<Building>> GetBuildingById(int id)
        {
            try
            {
                var building = await this.buildingRepository.GetBuildingById(id);
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
