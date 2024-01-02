using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;

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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarberShop>()
                .HasMany(bs => bs.Appointments)
                .WithOne(a => a.BarberShop)
                .HasForeignKey(a => a.BarberShopId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BarberShop>()
                .HasMany(bs => bs.Services)
                .WithOne(s => s.BarberShop)
                .HasForeignKey(s => s.BarberShopId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BarberShop>()
                .HasMany(bs => bs.ServiceCategories)
                .WithOne(sc => sc.BarberShop)
                .HasForeignKey(sc => sc.BarberShopId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BarberShop>()
                .HasMany(bs => bs.Reviews)
                .WithOne(r => r.BarberShop)
                .HasForeignKey(r => r.BarberShopId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.BarberShop)
                .WithMany(bs => bs.Services)
                .HasForeignKey(s => s.BarberShopId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Service>()
                .HasMany(s => s.Appointments)
                .WithOne(a => a.Service)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ServiceCategory>()
                .HasOne(sc => sc.BarberShop)
                .WithMany(bs => bs.ServiceCategories)
                .HasForeignKey(sc => sc.BarberShopId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}