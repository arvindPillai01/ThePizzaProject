using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaProj1.Models;

namespace PizzaProj1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaItem> Pizzas { get; set; }
        public DbSet<CartItem> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationship between Cart and Pizza
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Pizza)
                .WithMany()
                .HasForeignKey(c => c.PizzaId);
        }
    }
}
