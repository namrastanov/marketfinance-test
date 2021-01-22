using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers
{
    internal interface IApplicationServiceWorker
    {
        IApplicationResult SubmitApplication(ISellerApplication application);
        IApplicationServiceWorker ValidateApplication(ISellerApplication application);
    }
}
