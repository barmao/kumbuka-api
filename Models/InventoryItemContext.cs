using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kumbuka_api.Models
{
    public class InventoryItemContext : DbContext
    {
        public InventoryItemContext(DbContextOptions<InventoryItemContext> options)
    : base(options)
        {
        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}
