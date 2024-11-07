using InventoryManagemantSystem.Presentation;

namespace InventoryManagemantSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============= Welcome to the Inventory Management System =============\n");

            InventoryAppMenu inventoryAppMenu = new InventoryAppMenu();
            inventoryAppMenu.AppMenu();
        }
    }
}
