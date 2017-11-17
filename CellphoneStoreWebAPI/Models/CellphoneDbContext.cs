
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CellphoneStoreWebAPI.Models
{
    public class ApplicationUser : IdentityUser { }
    public class CellphoneDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailedOrder> DetailedOrders { get; set; }


        public CellphoneDbContext(DbContextOptions options) : base(options)
        {

        }


    }
}
