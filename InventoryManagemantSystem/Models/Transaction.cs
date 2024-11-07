using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagemantSystem.Type;

namespace InventoryManagemantSystem.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public Stock Type { get; set; } 
        public int Quantity { get; set; }
        public DateTime Date { get; set; }


        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        

        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"Transaction id : {TransactionId}\n" +
                $"Payment Type : {Type}\n" +
                $"Quantity : {Quantity}\n" +
                $"Date Of Transaction : {Date}\n" +
                $"Product Name : {Product.ProductName}";
        }
    }
}
