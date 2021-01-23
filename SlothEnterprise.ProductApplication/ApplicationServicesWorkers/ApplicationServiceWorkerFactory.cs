using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1;
using SlothEnterprise.ProductApplication.Exceptions;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers
{
    internal class ApplicationServiceWorkerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IDictionary<Type, Type> _productServiceWorkerMap
            = new Dictionary<Type, Type>()
        {
            { typeof(SelectiveInvoiceDiscount), typeof(SelectInvoiceServiceWorker) },
            { typeof(ConfidentialInvoiceDiscount), typeof(ConfidentialInvoiceServiceWorker) },
            { typeof(BusinessLoans), typeof(BusinessLoansServiceWorker) }
        };

        public ApplicationServiceWorkerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IApplicationServiceWorker GetServiceWorker(IProduct product)
        {
            var workerItem = _productServiceWorkerMap.FirstOrDefault(p => p.Key.Equals(product.GetType()));

            if (workerItem.Value != null)
            {
                return (IApplicationServiceWorker)Activator.CreateInstance(workerItem.Value, _serviceProvider);
            }

            throw new ProductApplicationException("Product is not supported");
        }
    }
}
