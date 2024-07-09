using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SkinetContext _skinetContext;

        public GenericRepository(SkinetContext skinetContext)
        {
            _skinetContext = skinetContext;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _skinetContext.Set<T>().FindAsync(id);
        }     

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _skinetContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_skinetContext.Set<T>().AsQueryable(), spec);
        }        
    }
}
