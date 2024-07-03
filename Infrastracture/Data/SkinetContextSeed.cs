using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastracture.Data
{
    public class SkinetContextSeed
    {
        public static async Task SeedAsync(SkinetContext skinetContext)
        {
            if (!skinetContext.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastracture/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                skinetContext.ProductTypes.AddRange(types);
            }
            if (!skinetContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastracture/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<productBrand>>(brandsData);
                skinetContext.ProductBrands.AddRange(brands);
            }
            if (!skinetContext.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastracture/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Products>>(productsData);
                skinetContext.Products.AddRange(products);
            }
            if (skinetContext.ChangeTracker.HasChanges())
            { 
                await skinetContext.SaveChangesAsync();
            }
        }
    }
}
