using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Model.Entities;

namespace Restaurant.DataAccess
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemOption> OrderItemOptions { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Restaurant_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>(ConfigureProductType);
            modelBuilder.Entity<Product>(ConfigureProduct);
            modelBuilder.Entity<ProductOption>(ConfigureProductOption);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, ProductTypeId = 1, Name = "Margheritta", Price = 20 },
                new Product { Id = 2, ProductTypeId = 1, Name = "Vegetariana", Price = 22 },
                new Product { Id = 3, ProductTypeId = 1, Name = "Tosca", Price = 25 },
                new Product { Id = 4, ProductTypeId = 1, Name = "Venecia", Price = 25 },
                new Product { Id = 5, ProductTypeId = 2, Name = "Schabowy z frytkami", Price = 30 },
                new Product { Id = 6, ProductTypeId = 2, Name = "Schabowy z ryzem", Price = 30 },
                new Product { Id = 7, ProductTypeId = 2, Name = "Schabowy z ziemniakami", Price = 30 },
                new Product { Id = 8, ProductTypeId = 2, Name = "Ryba z frytkami", Price = 28 },
                new Product { Id = 9, ProductTypeId = 2, Name = "Placek po węgiersku", Price = 27 },
                new Product { Id = 10, ProductTypeId = 3, Name = "Pomidorowa", Price = 12 },
                new Product { Id = 11, ProductTypeId = 3, Name = "Rosół", Price = 10 },
                new Product { Id = 12, ProductTypeId = 4, Name = "Kawa", Price = 5 },
                new Product { Id = 13, ProductTypeId = 4, Name = "Herbata", Price = 5 },
                new Product { Id = 14, ProductTypeId = 4, Name = "Cola", Price = 5 }
                );
        }

        private void ConfigureProductType(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                new ProductType { Id = 1, Type = "Pizza" },
                new ProductType { Id = 2, Type = "Dania główne" },
                new ProductType { Id = 3, Type = "Zupy" },
                new ProductType { Id = 4, Type = "Napoje" }
                );
        }

        private void ConfigureProductOption(EntityTypeBuilder<ProductOption> builder)
        {
            builder.HasData(
                new ProductOption { Id = 1, ProductTypeId=1, Name = "Podwojny ser", Price=2 },
                new ProductOption { Id = 2, ProductTypeId = 1, Name = "Salami", Price = 2 },
                new ProductOption { Id = 3, ProductTypeId = 1, Name = "Szynka", Price = 2 },
                new ProductOption { Id = 4, ProductTypeId = 1, Name = "Pieczarki", Price = 2 },
                new ProductOption { Id = 5, ProductTypeId = 2, Name = "Bar salatkowy", Price = 5 },
                new ProductOption { Id = 6, ProductTypeId = 2, Name = "Zestaw sosow", Price = 6 }
                );
        }
    }
}
