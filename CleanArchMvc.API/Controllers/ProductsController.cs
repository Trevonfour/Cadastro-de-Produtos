using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _productService.GetProducts();

            if (products == null)
                return NotFound("Products not found");

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return BadRequest("Invalid Data");

            await _productService.Add(productDto);
            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest("Invalid Id");

            if (productDto == null)
                return BadRequest("Invalid Data");

            await _productService.Update(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productDto = await _productService.GetById(id);

            if (productDto == null)
                return NotFound("Product not found");

            await _productService.Remove(id);
            return Ok(productDto);
        }
    }
}
