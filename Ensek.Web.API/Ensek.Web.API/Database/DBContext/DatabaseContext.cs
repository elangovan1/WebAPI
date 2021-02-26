using Ensek.Web.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Web.API.Database
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<MeterReading> MeterReading { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<MeterReading>().ToTable("MeterReading");

            modelBuilder.Entity<Account>()
                            .HasMany(x => x.MeterReadings)
                            .WithOne(x => x.Account)
                            .IsRequired();
                            
        }
    }
}
