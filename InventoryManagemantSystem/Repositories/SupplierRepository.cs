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
    internal class SupplierRepository
    {
        private InventoryContext _inventoryContext;
        public SupplierRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public void AddSupplier(string name, string contactInfo,int inventoryId)
        {
            var supplier = new Supplier { Name = name, ContactInfo = contactInfo, InventoryId = inventoryId};
            _inventoryContext.suppliers.Add(supplier);
            _inventoryContext.SaveChanges();
        }

        public Supplier FindSupplierByName(string name)
        {
            var supplier = _inventoryContext.suppliers.FirstOrDefault(s => s.Name == name);
            if (supplier == null)
            {
                throw new NoSuchSupplierExistException("Supplier With this Id Does not Exist");
            }
            return supplier;
        }
        public bool CheckSupplier(string name)
        {
            var supplierList = GetAllSuppliers();
            foreach (var supplier in supplierList)
            {
                {
                    if (supplier.Name == name)
                    {
                        throw new SupplierExistException("Supplier Already Exist Exception");
                    }
                }
            }
            return true;
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _inventoryContext.suppliers.ToList();
        }

        public void UpdateSupplier(Supplier supplier, string name, string contact, int inventory)
        {
            supplier.Name = name;
            supplier.ContactInfo = contact;
            supplier.InventoryId = inventory;
            _inventoryContext.Entry(supplier).State = EntityState.Modified;
            _inventoryContext.SaveChanges();
        }

        public void DeleteSupplier(Supplier supplier)
        {
            _inventoryContext?.suppliers.Remove(supplier);
            _inventoryContext?.SaveChanges();
        }
    }
}
