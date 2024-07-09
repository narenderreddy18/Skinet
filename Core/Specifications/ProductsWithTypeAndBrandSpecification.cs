using Core.Entities;
using System.Net.Security;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandSpecification: BaseSpecification<Products>
    {
        public ProductsWithTypeAndBrandSpecification(productsSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.productBrand);
            AddOrderBy(x => x.Name);
            ApplyPagination(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithTypeAndBrandSpecification(int id) 
            : base(x =>x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.productBrand);
        }
    }
}
