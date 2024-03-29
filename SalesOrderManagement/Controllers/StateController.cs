﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Net;

namespace SalesOrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository StateRepository;
        public StateController(IStateRepository StateRepository)
        {
            this.StateRepository = StateRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<DTOState>>> GetStates()
        {
            try
            {
                var States = await this.StateRepository.GetStates();
                if (States == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(States);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(DTOState model)
        {
            try
            {
                var result = await this.StateRepository.Create(model);
                if (result)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error storing data in the database");
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<DTOState>> GetStateById(int id)
        {
            try
            {
                var State = await this.StateRepository.GetStateById(id);
                if (State == null)
                {
                    return NotFound();
                }
                return Ok(State);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<bool>> Update(DTOState model)
        {
            try
            {
                var result = await this.StateRepository.Update(model);
                if (result)
                {
                    return Ok(result);
                }
               return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error storing data in the database");
            }
        }

      
    }
}

