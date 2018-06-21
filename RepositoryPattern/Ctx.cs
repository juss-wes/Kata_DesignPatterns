using RepositoryPattern.Entities;
using System.Data.Entity;

namespace RepositoryPattern
{
    class Ctx : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProductUnits> OrderProductUnits { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
