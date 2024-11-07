using InventoryManagemantSystem.Data;
using InventoryManagemantSystem.Exceptions;
using InventoryManagemantSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Repositories
{
    internal class TransactionRepository
    {
        private InventoryContext _inventoryContext;
        public TransactionRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public void AddStock(string name,int quantity)
        {
            var product = _inventoryContext.Products.FirstOrDefault(p => p.ProductName == name);
            if (product == null)
            {
                throw new NoSuchProductExistException("No Such Product Exist");
            }
            
            var transaction = new Transaction() { Type = Type.Stock.ADD, Quantity = quantity, Date = DateTime.Now, InventoryId = product.InventoryId, ProductId = product.ProductId };

            product.ProductQuantity += quantity;
            _inventoryContext.transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }

        public void RemoveStock(string name, int quantity)
        {
            var product = _inventoryContext.Products.FirstOrDefault(p => p.ProductName == name);
            if (product == null)
            {
                throw new NoSuchProductExistException("No Such Product Exist");
            }

            var transaction = new Transaction() { Type = Type.Stock.REMOVE, Quantity = quantity, Date = DateTime.Now, InventoryId = product.InventoryId, ProductId = product.ProductId };

            product.ProductQuantity -= quantity;
            _inventoryContext.transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }
        public List<Transaction> GetTransactions(string name)
        {
            var product = _inventoryContext.Products.FirstOrDefault(p => p.ProductName == name);
            if (product == null)
            {
                throw new NoSuchProductExistException("No Such Product Exist");
            }

            var transactionList = _inventoryContext.transactions.Where(t => t.ProductId == product.ProductId).ToList();
            if (transactionList.Count == null)
            {
                throw new NoTransactionException("NO transaction For this Product");
            }
            return transactionList;
        }

        
    }
}
