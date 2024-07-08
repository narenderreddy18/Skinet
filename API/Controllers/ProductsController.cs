using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IGenericRepository<Products> _productsRepo;
        private readonly IGenericRepository<productBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Products> productsRepo, 
            IGenericRepository<productBrand> productBrandRepo, 
            IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductsWithTypeAndBrandSpecification();
            var products = await _productsRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Products>, IReadOnlyList<ProductToReturnDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProductsByID(int id)
        {
            var spec = new ProductsWithTypeAndBrandSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Products, ProductToReturnDTO>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<Products>>> GetProductTypes()
        {
            var types = await _productBrandRepo.ListAllAsync();
            return Ok(types);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Products>>> GetProductBrands()
        {
            var brands = await _productTypeRepo.ListAllAsync();
            return Ok(brands);
        }
    }
}
