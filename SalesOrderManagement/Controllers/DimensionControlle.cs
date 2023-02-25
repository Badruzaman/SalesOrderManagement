﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dimension>>> GetDimensions()
        {
            try
            {
                var Dimensions = await this.DimensionRepository.GetDimensions();
                if (Dimensions == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Dimensions);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(DTODimension model)
        {
            var result = await this.DimensionRepository.Create(model);
            return Ok(result);
        }
        [HttpGet("id")]
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}

