using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Domain
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
