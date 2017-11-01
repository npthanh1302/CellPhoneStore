using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellphoneStoreWebAPI.Models
{
    public class CellphoneDbContext : DbContext
    {
        public DbSet<Cellphone> Cellphones { get; set; }

        public CellphoneDbContext  (DbContextOptions options) : base(options)
        {

        }
    }
}
