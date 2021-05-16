using System;

namespace MP03.ModelValidationException
{
    public class ModelException : Exception
    {
        public ModelException()
        {
            
        }
        public ModelException(string message) : base(message)
        {
            
        }
    }
}