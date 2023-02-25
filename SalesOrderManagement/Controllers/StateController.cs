using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(DTOState model)
        {
            var result = await this.StateRepository.Create(model);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<ActionResult<State>> GetStateById(int id)
        //{
        //    try
        //    {
        //        var State = await this.StateRepository.GetStateById(id);
        //        if (State == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(State);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }

        //}
    }
}

