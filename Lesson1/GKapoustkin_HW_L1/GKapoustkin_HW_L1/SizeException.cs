using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKapoustkin_HW_L1
{
    class SizeException : Exception
    {
        public SizeException(string message) : base(message) { }
    }
}
