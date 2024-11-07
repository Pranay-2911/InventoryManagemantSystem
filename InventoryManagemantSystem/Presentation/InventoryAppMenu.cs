using InventoryManagemantSystem.Exceptions;
using InventoryManagemantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Presentation
{
    internal class InventoryAppMenu
    {

        private ProductMenu productMenu = new ProductMenu();
        private SuppilerMenu suppilerMenu = new SuppilerMenu();
        private TransactionMenu transactionMenu = new TransactionMenu();
        private InventoryMenu inventoryMenu = new InventoryMenu();
        public void AppMenu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("1. Project Management\n" +
                "2. Supplier Management\n" +
                "3. Transaction Management\n" +
                "4. Generate Report\n" +
                "5. Exit\n");

                Console.WriteLine("Enter Your choice");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        productMenu.ProductManagement();
                        break;
                    case 2:
                        suppilerMenu.SupplierManagement();
                        break;
                    case 3:
                        transactionMenu.TransactionManagement();
                        break;
                    case 4:
                        inventoryMenu.GenerateReport();
                        break;
                    case 5:
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Enter Correct Choice");
                        break;
                }
            }
        }
                                                               
        
    }
}
