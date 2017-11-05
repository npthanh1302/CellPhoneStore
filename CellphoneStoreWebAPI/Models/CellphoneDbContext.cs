using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CellphoneStoreWebAPI.Models
{
    public class CellphoneDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Brand> Brands { get; set; }


        public CellphoneDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Item>()
        //    .HasOne(e => e.ItemDetail).WithOne(e => e.Item)
        //    .HasForeignKey<ItemDetail>(e => e.ItemID);

        //    modelBuilder.Entity<Item>().ToTable("Items");
        //    modelBuilder.Entity<ItemDetail>().ToTable("Items");
        //}

    }
}
