using System;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly ApplicationServiceWorkerFactory _serviceFactory;

        public ProductApplicationService(IServiceProvider serviceProvider)
        {
            _serviceFactory = new ApplicationServiceWorkerFactory(serviceProvider);
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var applicationResult = _serviceFactory
                .GetWorker(application.Product)
                .ValidateApplication(application)
                .SubmitApplication(application);

            return applicationResult.Success ? applicationResult.ApplicationId ?? -1 : -1;
        }
    }
}
