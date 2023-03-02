using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.Api.Entities;
using SalesOrderManagement.Api.Repositories.Contracts;
using SalesOrderManagement.Models.DTOs;
using System.Net;

namespace SalesOrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository ProductRepository;
        public ProductController(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOProduct>>> GetProducts()
        {
            try
            {
                var Products = await this.ProductRepository.GetProducts();
                if (Products == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Products);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        [HttpPost]
        public async Task<ActionResult<bool>> Create(DTOProduct model)
        {
            try
            {
                var result = await this.ProductRepository.Create(model);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error storing data in the database");
            }
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<DTOProduct>> GetProductById(int id)
        {
            try
            {
                var Product = await this.ProductRepository.GetProductById(id);
                if (Product == null)
                {
                    return NotFound();
                }
                return Ok(Product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<HttpResponseMessage>> Update(DTOProduct model)
        {
            try
            {
                var result = await this.ProductRepository.Update(model);
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

        [HttpGet("GetProductAttributes")]
        public async Task<ActionResult<DTOProductAttribute>> GetProductAttributes()
        {
            try
            {
                var ProductAttribute = await this.ProductRepository.GetProductAttributes();
                if (ProductAttribute == null)
                {
                    return NotFound();
                }
                return Ok(ProductAttribute);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}

