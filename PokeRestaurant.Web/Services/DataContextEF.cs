///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Microsoft.EntityFrameworkCore;
using PokeRestaurant.Data.Entity;

namespace PokeRestaurant.Web.Services
{
    public class DataContextEF:DbContext
    {
         
        public DataContextEF(DbContextOptions<DataContextEF>options):base(options)
        {
           // bool dbCreated = Database.EnsureCreated();
        }

      

        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartLine> ShoppingCartLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PokeRestaurant");

            modelBuilder.Entity<MenuItem>().HasKey(mi => mi.ID);
            modelBuilder.Entity<Order>().HasKey(o=> o.ID);
            modelBuilder.Entity<ShoppingCart>().HasKey(oi => oi.ID);
            modelBuilder.Entity<ShoppingCartLine>().HasKey(oi => oi.ID);    
        }

        
        
    }
}
