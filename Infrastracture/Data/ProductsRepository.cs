using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly SkinetContext _skinetContext;
        public ProductsRepository(SkinetContext skinetContext)
        {
            _skinetContext = skinetContext;
        }
        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            return await _skinetContext.Products
                .Include(b => b.productBrand)
                .Include(t => t.ProductType)
                .ToListAsync();
        }
        public async Task<Products> GetProductByIDAsync(int id)
        {
            return await _skinetContext.Products
                .Include(b => b.productBrand)
                .Include(t => t.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _skinetContext.ProductTypes.ToListAsync();
        }
        public async Task<IReadOnlyList<productBrand>> GetProductBrandsAsync()
        {
            return await _skinetContext.ProductBrands.ToListAsync();
        }
    }
}
