using System;
using System.Runtime.Serialization;

namespace SlothEnterprise.ProductApplication.Exceptions
{
    public class ProductApplicationException : Exception
    {
        public ProductApplicationException()
        {
        }

        public ProductApplicationException(string message) : base(message)
        {
        }

        public ProductApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
