using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagemantSystem.Exceptions
{
    internal class NoTransactionException : Exception
    {
        public NoTransactionException(string message) : base(message)
        {
            
        }
    }
}
