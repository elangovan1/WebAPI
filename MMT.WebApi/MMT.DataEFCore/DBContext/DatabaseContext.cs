using Microsoft.EntityFrameworkCore;
using MMT.Domain.Model;

namespace MMT.DataEFCore.DBContext
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        } 
         public virtual DbSet<CustomerModel> Customers { get; set; }
         public virtual DbSet<OrderModel> Orders { get; set; }
         public virtual DbSet<ProductModel> Products { get; set; }
         public virtual DbSet<OrderItemModel> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().ToTable("Products");
            modelBuilder.Entity<OrderModel>().ToTable("Orders");
            modelBuilder.Entity<OrderItemModel>().ToTable("OrderItems");
            modelBuilder.Entity<CustomerModel>().ToTable("Customer");
        }
    }
}
