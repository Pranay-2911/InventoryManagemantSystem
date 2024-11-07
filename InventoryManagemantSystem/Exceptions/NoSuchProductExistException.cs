using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Exceptions
{
    internal class NoSuchProductExistException : Exception
    {
        public NoSuchProductExistException(string message) : base (message)
        {
            
        }
    }
}
