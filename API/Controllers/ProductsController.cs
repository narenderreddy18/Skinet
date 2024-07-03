using Core.Entities;
using Core.Interfaces;
using Infrastracture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepo;
        public ProductsController(IProductsRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var products = await _productsRepo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Products>>> GetProductsByID(int id)
        {
            var products = await _productsRepo.GetProductByIDAsync(id);
            return Ok(products);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<Products>>> GetProductTypes()
        {
            var types = await _productsRepo.GetProductTypesAsync();
            return Ok(types);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<Products>>> GetProductBrands()
        {
            var brands = await _productsRepo.GetProductBrandsAsync();
            return Ok(brands);
        }
    }
}
