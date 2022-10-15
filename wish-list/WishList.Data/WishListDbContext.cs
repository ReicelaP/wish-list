using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WishList.Core.Models;

namespace WishList.Data
{
    public class WishListDbContext : DbContext, IWishListDbContext
    {
        public WishListDbContext(DbContextOptions options) : 
            base(options) { }

        public DbSet<Wish> Wishes { get; set; }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
