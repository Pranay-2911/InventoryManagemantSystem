using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Exceptions
{
    class SupplierExistException : Exception
    {
        public SupplierExistException(string message) : base(message) { }
    }
}
