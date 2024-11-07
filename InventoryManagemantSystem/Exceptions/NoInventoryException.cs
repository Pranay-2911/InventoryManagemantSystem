using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Exceptions
{
    internal class NoInventoryException : Exception
    {
        public NoInventoryException(string message) : base(message)
        {
            
        }
    }

}
