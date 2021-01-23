using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Exceptions;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1
{
    internal abstract class BaseApplicationServiceWorker : IApplicationServiceWorker
    {
        protected ISellerApplication Application;
        protected IApplicationResult ApplicationResult;

        public IApplicationServiceWorker SetApplication(ISellerApplication application)
        {
            Application = application;
            return this;
        }

        public IApplicationServiceWorker CheckErrors()
        {
            if (ApplicationResult.Errors != null && ApplicationResult.Errors.Count > 0)
            {
                throw new ProductApplicationException($"Errors: {string.Join(",", ApplicationResult.Errors)}");
            }

            return this;
        }

        public IApplicationResult GetResult()
        {
            return ApplicationResult;
        }

        public abstract IApplicationServiceWorker Submit();

        public abstract IApplicationServiceWorker Validate();
    }
}
