using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUNet
{
    public class GRUException : Exception
    {
        public GRUException(string message) : base(message)
        {
        }
    }
}
