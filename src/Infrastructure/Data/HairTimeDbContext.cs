using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Domain.Entities;

namespace Infrastructure.Data
{
    public class HairTimeDbContext : DbContext
    {
        public DbSet<BarberShop> BarberShops { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public HairTimeDbContext(DbContextOptions<HairTimeDbContext> options) : base(options)
        {
        }
    }
}