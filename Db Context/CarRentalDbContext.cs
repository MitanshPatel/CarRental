using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Db_Context
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {
        }

        public required DbSet<CarClass> Cars { get; set; }
        public required DbSet<UserClass> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity properties and relationships here
            modelBuilder.Entity<CarClass>().ToTable("Cars");
            modelBuilder.Entity<UserClass>().ToTable("Users");
        }
    }
}
