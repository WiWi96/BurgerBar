using BurgerBar.Entities;
using Microsoft.EntityFrameworkCore;

namespace BurgerBar.Data
{
    public class BurgerBarContext : DbContext
    {
        public BurgerBarContext(DbContextOptions<BurgerBarContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientType>().HasData(
                new IngredientType()
                {
                    Id = 1,
                    Name = "Meat"
                },
                new IngredientType()
                {
                    Id = 2,
                    Name = "Cheese"
                },
                new IngredientType()
                {
                    Id = 3,
                    Name = "Sauce"
                },
                new IngredientType()
                {
                    Id = 4,
                    Name = "Vegetable"
                },
                new IngredientType()
                {
                    Id = 5,
                    Name = "Spice"
                }
            );

            modelBuilder.Entity<Burger>()
                .Property(b => b.Number)
                .HasDefaultValue(string.Empty);
        }

        public DbSet<Burger> Burger { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<IngredientType> IngredientType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Bun> Bun { get; set; }
        public DbSet<DeliveryType> DeliveryType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<User> User { get; set; }
    }
}
