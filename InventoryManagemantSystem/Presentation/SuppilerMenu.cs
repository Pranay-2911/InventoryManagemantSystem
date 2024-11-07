using InventoryManagemantSystem.Exceptions;
using InventoryManagemantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Presentation
{
    internal class SuppilerMenu
    {
        static SupplierRepository supplierRepository = new SupplierRepository();
        public void SupplierManagement()
        {
            bool check2 = true;
            while (check2)
            {
                Console.WriteLine("1 Add Supplier\n" +
                "2 Update Supplier\n" +
                "3 Delete Supplier\n" +
                "4 View Supplier's Details\n" +
                "5 View All Suppliers\n" +
                "6 Go Back Main Menu\n" +
                "Enter Your Choice\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddSupplier();
                        break;
                    case 2:
                        UpdateSupplier();
                        break;
                    case 3:
                        DeleteSupplier();
                        break;
                    case 4:
                        ViewSupplier();
                        break;
                    case 5:
                        ViewAllSupplier();
                        break;
                    case 6:
                        check2 = false;
                        break;
                    default:
                        Console.WriteLine("Enter Correct Choice");
                        break;

                }
            }
        }
        public void AddSupplier()
        {
            try
            {
                Console.WriteLine("Enter the Supplier Name");
                string name = Console.ReadLine();
                if (supplierRepository.CheckSupplier(name))
                {
                    Console.WriteLine("Enter the Supplier Contact Info");
                    string contactInfo = Console.ReadLine();
                    Console.WriteLine("Enter Inventory Id");
                    int inventoryId = int.Parse(Console.ReadLine());

                    supplierRepository.AddSupplier(name, contactInfo, inventoryId);
                    Console.WriteLine("Added Successfully");
                }
            }
            catch (SupplierExistException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateSupplier()
        {
            try
            {
                Console.WriteLine("Enter the Supplier Name");
                string name = Console.ReadLine();

                var suppiler = supplierRepository.FindSupplierByName(name);

                Console.WriteLine("Enter the Supplier Contact Info");
                string contactInfo = Console.ReadLine();
                Console.WriteLine("Enter Inventory Id");
                int inventoryId = int.Parse(Console.ReadLine());

                supplierRepository.UpdateSupplier(suppiler, name, contactInfo, inventoryId);
                Console.WriteLine("Updated Successfully");
            }
            catch (NoSuchSupplierExistException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DeleteSupplier()
        {
            try
            {
                Console.WriteLine("Enter the Supplier Name");
                string name = Console.ReadLine();

                var suppiler = supplierRepository.FindSupplierByName(name);

                supplierRepository.DeleteSupplier(suppiler);
                Console.WriteLine("Deleted Successfully");
            }
            catch (NoSuchSupplierExistException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewSupplier()
        {
            try
            {
                Console.WriteLine("Enter the Supplier Name");
                string name = Console.ReadLine();

                var suppiler = supplierRepository.FindSupplierByName(name);

                Console.WriteLine(suppiler.ToString());
            }
            catch (NoSuchSupplierExistException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ViewAllSupplier()
        {
            var supplierList = supplierRepository.GetAllSuppliers();

            foreach (var supplier in supplierList)
            {
                Console.WriteLine(supplier.ToString());
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}
