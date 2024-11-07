using InventoryManagemantSystem.Exceptions;
using InventoryManagemantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Presentation
{
    internal class ProductMenu
    {
        static ProductRepository productRepository = new ProductRepository();

        public void ProductManagement()
        {
            bool check1 = true;
            while (check1)
            {
                Console.WriteLine("1 Add Product\n" +
               "2 Update Product\n" +
               "3 Delete Product\n" +
               "4 View Product Details\n" +
               "5 View All Products\n" +
               "6 Go Back Main Menu\n" +
               "Enter Your Choice\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        ViewProduct();
                        break;
                    case 5:
                        ViewAllProduct();
                        break;
                    case 6:
                        check1 = false;
                        break;
                    default:
                        Console.WriteLine("Enter Correct Choice");
                        break;

                }
            }
        }

        public void AddProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Name");
                string name = Console.ReadLine();
                if (productRepository.CheckProduct(name))
                {
                    Console.WriteLine("Enter Product Description");
                    string describtion = Console.ReadLine();
                    Console.WriteLine("Enter Product Quantity");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Product Price");
                    double price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Inventory Id");
                    int inventoryId = int.Parse(Console.ReadLine());

                    productRepository.AddProduct(name, describtion, quantity, price, inventoryId);
                    Console.WriteLine("Added Successfully");
                }
            }
            catch (ProductExistException pe)
            {
                Console.WriteLine(pe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter product Name ");
                string name = Console.ReadLine();
                var product = productRepository.FindProductByName(name);
                
                Console.WriteLine("Enter Product Description");
                string describtion = Console.ReadLine();
                Console.WriteLine("Enter Product Quantity");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Product Price");
                double price = int.Parse(Console.ReadLine());

                productRepository.UpdateProduct(product, name, describtion, quantity, price);
                Console.WriteLine("Updated Succesfully");

            }
            catch (NoSuchProductExistException np)
            {
                Console.WriteLine(np.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product Name ");
                string name = Console.ReadLine();

                var product = productRepository.FindProductByName(name);

                productRepository.DeleteProduct(product);
                Console.WriteLine("Deleted Successfully");

            }
            catch (NoSuchProductExistException np)
            {
                Console.WriteLine(np.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ViewProduct()
        {
            try
            {
                Console.WriteLine("Enter product Name ");
                string name = Console.ReadLine();

                var product = productRepository.FindProductByName(name);

                Console.WriteLine(product.ToString());
            }
            catch (NoSuchProductExistException np)
            {
                Console.WriteLine(np.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ViewAllProduct()
        {
            var productList = productRepository.GetAllProduct();
            foreach (var product in productList)
            {
                Console.WriteLine(product.ToString());
                Console.WriteLine("-------------------------------------------------\n");
            }
        }
    }
}
