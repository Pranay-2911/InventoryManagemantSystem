using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Exceptions
{
    internal class NoSuchSupplierExistException : Exception
    {
        public NoSuchSupplierExistException(string message) : base(message)
        { }
    }
}
