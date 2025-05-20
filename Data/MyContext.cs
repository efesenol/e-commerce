using e_commerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Users> Users => Set<Users>();
        public DbSet<Products> Products => Set<Products>();
        public DbSet<Menus> Menus => Set<Menus>();
        public DbSet<Basket> Basket => Set<Basket>();
        public DbSet<BasketItem> BasketItem => Set<BasketItem>();
        
       


    }
}