using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Models
{
    internal class Inventory
    {
        [Key]
        public int InventoryId { get; set; }  
        public string Location { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public override string ToString()
        {
            return $"Inventory ID : {InventoryId}\n" +
                $"Location : {Location}";
        }
    }
}
