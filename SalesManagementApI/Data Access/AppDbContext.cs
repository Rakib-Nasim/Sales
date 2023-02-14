using Microsoft.EntityFrameworkCore;
using SalesManagementApI.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApI.Data_Access
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCustomer>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<ProductCustomer>()
                .HasOne(i => i.Customer)
                .WithMany(j => j.ProductCustomer)
                .HasForeignKey(k => k.CustomerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ProductCustomer>()
                .HasOne(i => i.Product)
                .WithMany(j => j.ProductCustomer)
                .HasForeignKey(k => k.ProductId)
                .OnDelete(DeleteBehavior.ClientCascade);

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductCustomer> ProductCustomers { get; set; }
    }
}
