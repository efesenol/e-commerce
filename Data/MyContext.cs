using e_commerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
       


    }
}