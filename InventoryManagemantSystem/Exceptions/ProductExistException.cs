using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Exceptions
{
    internal class ProductExistException : Exception
    {
        public ProductExistException(string message) : base(message) { }
    }
}
