using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Models
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }


        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }


        public override string ToString()
        {
            return $"\nProduct name: {ProductName}\n" +
                    $"Product Description : {ProductDescription}\n" +
                    $"Product Quantity : {ProductQuantity}\n" +
                    $"Product Price : {ProductPrice}";
        }
    }
}
