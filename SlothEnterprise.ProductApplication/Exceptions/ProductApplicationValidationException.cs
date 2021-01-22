using System;
using System.Runtime.Serialization;

namespace SlothEnterprise.ProductApplication.Exceptions
{
    public class ProductApplicationValidationException : ProductApplicationException
    {
        public ProductApplicationValidationException()
        {
        }

        public ProductApplicationValidationException(string message) : base(message)
        {
        }

        public ProductApplicationValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductApplicationValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
