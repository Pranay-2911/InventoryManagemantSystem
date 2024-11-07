using InventoryManagemantSystem.Exceptions;
using InventoryManagemantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Presentation
{
    internal class TransactionMenu
    {
        static TransactionRepository transactionRepository = new TransactionRepository();
        public void TransactionManagement()
        {
            bool check3 = true;
            while (check3)
            {
                Console.WriteLine("1 Add Stock\n" +
               "2 Remove Stock\n" +
               "3 View Transaction History\n" +
               "4 Go Back Main Menu\n" +
               "Enter Your Choice\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStock();
                        break;
                    case 2:
                        RemoveStock();
                        break;
                    case 3:
                        ViewTransactionHistory();
                        break;
                    case 4:
                        check3 = false;
                        break;
                    default:
                        Console.WriteLine("Enter Correct Choice");
                        break;

                }
            }
        }
        public void AddStock()
        {
            try
            {
                
                Console.WriteLine("Enter Product name to Add Stock");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the Qauntity of Stock to Add");
                int quantity = int.Parse(Console.ReadLine());
                transactionRepository.AddStock(name,quantity);
                Console.WriteLine("Stock Added SuccesFully");
            }
            catch (NoSuchProductExistException nt)
            {
                Console.WriteLine(nt.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RemoveStock()
        {
            try
            {
                Console.WriteLine("Enter Product name to Add Stock");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Qauntity of Stock to Add");
                int quantity = int.Parse(Console.ReadLine());
                transactionRepository.RemoveStock(name,quantity);
                Console.WriteLine("Stock Removed SuccesFully");
            }
            catch (NoSuchProductExistException nt)
            {
                Console.WriteLine(nt.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ViewTransactionHistory()
        {
            try
            {
                Console.WriteLine("Enter the Product Name to View Transaction History");
                string name = Console.ReadLine();

                var transactionList = transactionRepository.GetTransactions(name);

                foreach (var transaction in transactionList)
                {

                    Console.WriteLine(transaction.ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (NoTransactionException nt)
            {
                Console.WriteLine(nt.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
