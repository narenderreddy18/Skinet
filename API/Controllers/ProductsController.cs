using Core.Entities;
using Infrastracture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly SkinetContext _skinetContext;
        public ProductsController(SkinetContext skinetContext)
        {
            _skinetContext = skinetContext;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var products = await _skinetContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Products>>> GetProducts(int id)
        {
            var products = await _skinetContext.Products.FindAsync(id);
            return Ok(products);
        }
    }
}
