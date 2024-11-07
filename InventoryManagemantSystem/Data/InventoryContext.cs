using InventoryManagemantSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Data
{
    internal class InventoryContext : DbContext
    {
        public DbSet<Inventory> inventories {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Transaction> transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connString"]);
        }
    }
}
