using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Domain.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<Sex> Sexs { get; set; } 

    }
}
