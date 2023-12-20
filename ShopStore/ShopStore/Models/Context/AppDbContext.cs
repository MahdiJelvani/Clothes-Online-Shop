using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace ShopStore.Models.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Cart> Carts { get; set;}
        public DbSet<CartItem> CartItems { get; set;}  
        public DbSet<Category> Categories { get; set;}
        public DbSet<Order> Orders { get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // call the base if you are using Identity service.
            // Important
            base.OnModelCreating(builder);

            builder.Entity<User>()
            .HasOne(e => e.Cart)
        .WithOne(e => e.User)
        .HasForeignKey<Cart>(e => e.UserId);

            builder.Entity<Cart>()
         .HasMany(e => e.CartItems)
         .WithOne(e => e.Cart)
         .HasForeignKey(e => e.CartId);

            builder.Entity<Product>()
         .HasMany(e => e.CartItems)
         .WithOne(e => e.Product)
         .HasForeignKey(e => e.CartId);
        }
    }
}
