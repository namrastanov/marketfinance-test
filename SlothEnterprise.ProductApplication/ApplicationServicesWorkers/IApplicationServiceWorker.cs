using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers
{
    internal interface IApplicationServiceWorker
    {
        IApplicationServiceWorker SetApplication(ISellerApplication application);
        IApplicationServiceWorker Submit();
        IApplicationServiceWorker Validate();
        IApplicationServiceWorker CheckErrors();
        IApplicationResult GetResult();
    }
}
