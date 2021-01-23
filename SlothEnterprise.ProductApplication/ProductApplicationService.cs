using System;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly ApplicationServiceWorkerFactory _serviceWorkerFactory;

        public ProductApplicationService(IServiceProvider serviceProvider)
        {
            _serviceWorkerFactory = new ApplicationServiceWorkerFactory(serviceProvider);
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var applicationResult = _serviceWorkerFactory
                .GetWorker(application.Product)
                .SetApplication(application)
                .Validate()
                .Submit()
                .CheckErrors()
                .GetResult();

            return applicationResult.Success ? applicationResult.ApplicationId ?? -1 : -1;
        }
    }
}
