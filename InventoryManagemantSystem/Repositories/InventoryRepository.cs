using InventoryManagemantSystem.Data;
using InventoryManagemantSystem.Exceptions;
using InventoryManagemantSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Repositories
{
    internal class InventoryRepository
    {
        private InventoryContext _inventoryContext;
        public InventoryRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        public Inventory GetInventory(int id)
        {
            var inventory = _inventoryContext.inventories.Where(p => p.InventoryId == id).Include(p => p.Products).Include(t => t.Transactions).Include(s=> s.Suppliers).FirstOrDefault();

            if (inventory == null)
            {
                throw new NoInventoryException("No Inventory For This Id");
            }
            return inventory;
        }

        public double GetTotalCost(Inventory inventory)
        {
            double totalCost = 0;
            foreach (var product in inventory.Products)
            {
                totalCost += (product.ProductPrice * product.ProductQuantity);
            }
            return totalCost;
        }
    }
}
