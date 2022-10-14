using Microsoft.EntityFrameworkCore;
using WishList.Core.Models;

namespace WishList.Data
{
    public class WishListDbContext : DbContext
    {
        public WishListDbContext(DbContextOptions options) : 
            base(options) { }

        public DbSet<Wish> Wishes { get; set; }
    }
}
