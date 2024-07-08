using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandSpecification: BaseSpecification<Products>
    {
        public ProductsWithTypeAndBrandSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.productBrand);
        }

        public ProductsWithTypeAndBrandSpecification(int id) 
            : base(x =>x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.productBrand);
        }
    }
}
