using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductsRepository
    {
        Task<IReadOnlyList<Products>> GetProductsAsync();
        Task<Products> GetProductByIDAsync(int id);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<productBrand>> GetProductBrandsAsync();
    }
}
