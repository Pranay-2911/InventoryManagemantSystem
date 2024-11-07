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
    internal class ProductRepository
    {
        private InventoryContext _inventoryContext;
        public ProductRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public void AddProduct(string name, string description, int quantity, double price, int inventoryId)
        {
            

            var product = new Product { ProductName = name, ProductDescription = description, ProductQuantity = quantity, ProductPrice = price, InventoryId = inventoryId };

            _inventoryContext.Products.Add(product);
            _inventoryContext.SaveChanges();
        }

        public bool CheckProduct(string name)
        {
            var productList = GetAllProduct();
            foreach (var product in productList)
            {
                if (product.ProductName == name)
                    throw new ProductExistException("The Product With This Name Already Exist");
            }
            return true;
        }
   
        public Product FindProductByName(string name)
        {
            var product = _inventoryContext.Products.FirstOrDefault(x => x.ProductName == name);
            if (product == null)
            {
                throw new NoSuchProductExistException($"NO Such Product is Available With This name : {name} ");
            }
            return product;
        }

        public void UpdateProduct(Product product, string name, string description, int quantity, double price)
        {
            product.ProductName = name;
            product.ProductDescription = description;
            product.ProductQuantity = quantity;
            product.ProductPrice = price;
            _inventoryContext.Entry(product).State = EntityState.Modified;
            _inventoryContext.SaveChanges();

        }
        public void DeleteProduct(Product product)
        {
            _inventoryContext?.Products.Remove(product);
            _inventoryContext?.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            var productList = _inventoryContext.Products.ToList();
            return productList;
        }
    }
}
