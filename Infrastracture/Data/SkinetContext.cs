using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data
{
    public class SkinetContext : DbContext
    {
        public SkinetContext(DbContextOptions options): base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
