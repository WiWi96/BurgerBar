using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BurgerBar.Model;

namespace BurgerBar.Data
{
    public class BurgerBarContext : DbContext
    {
        public BurgerBarContext (DbContextOptions<BurgerBarContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>()
                .Property(b => b.Number)
                .HasDefaultValue(string.Empty);
        }

        public DbSet<Burger> Burger { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Bun> Bun { get; set; }
        public DbSet<DeliveryType> DeliveryType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<User> User { get; set; }
    }
}
