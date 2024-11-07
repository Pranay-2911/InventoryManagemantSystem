using InventoryManagemantSystem.Exceptions;
using InventoryManagemantSystem.Models;
using InventoryManagemantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Presentation
{
    internal class InventoryMenu
    {
        static InventoryRepository inventoryRepository = new InventoryRepository();
        static TransactionRepository transactionRepository = new TransactionRepository();
        public void GenerateReport()
        {
            try
            {
                Console.WriteLine("Enter the inventory Id");
                int id = int.Parse(Console.ReadLine());
                var inventory = inventoryRepository.GetInventory(id);
                PrintReport(inventory);
            }
            catch (NoInventoryException no)
            {
                Console.WriteLine(no.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   

        }
        public void PrintReport(Inventory inventory)
        {
            
            Console.WriteLine("\n-------------------------------------------------------------------------------\n");
            Console.WriteLine(inventory.ToString());
            Console.WriteLine($"\n" +
                $"Total Product : {inventory.Products.Count()}\n" +
                $"Total Cost Of Inventory : {inventoryRepository.GetTotalCost(inventory)}");


            Console.WriteLine("\nProducts:-----");
            inventory.Products.ForEach(product =>
           
                Console.WriteLine(product.ToString() + "\n")
            );

            Console.WriteLine("\nSuppliers:-----");
            inventory.Suppliers.ForEach(supplier =>

                Console.WriteLine(supplier.ToString() + "\n")
            );

            Console.WriteLine("\nTransactions:-----");
            inventory.Transactions.ForEach(transaction =>

                Console.WriteLine(transaction.ToString() + "\n")
            );

            Console.WriteLine("\n-------------------------------------------------------------------------------\n");
        }
    }
}
