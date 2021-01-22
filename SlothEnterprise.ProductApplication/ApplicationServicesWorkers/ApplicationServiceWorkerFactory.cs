using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1;
using SlothEnterprise.ProductApplication.Products;
using System;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers
{
    internal class ApplicationServiceWorkerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationServiceWorkerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IApplicationServiceWorker GetWorker(IProduct product)
        {
            if (product is BusinessLoans)
            {
                return new BusinessLoansServiceWorker(_serviceProvider);
            }
            if (product is ConfidentialInvoiceDiscount)
            {
                return new ConfidentialInvoiceServiceWorker(_serviceProvider);
            }

            throw new InvalidOperationException();
        }
    }
}
