using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP02.СustomException
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException() : base()
        {

        }
        public ModelValidationException(string message) : base(message)
        {
                
        }
    }
}
