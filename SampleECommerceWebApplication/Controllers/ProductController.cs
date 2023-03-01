using Ecommerce.Domain.Models;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleECommerceWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        { 
            _productService= productService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products= await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult> GetProductsByName(string name)
        {
            var products = await _productService.GetProductsByNameAsync(name);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok(product);
        }
    }
}
