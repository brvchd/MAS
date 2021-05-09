using System;

namespace MP01.Exceptions
{
    public class ModelValidationExceptions : Exception
    {
        public ModelValidationExceptions() { }
        public ModelValidationExceptions(string message) : base(message) { }
    }
}
