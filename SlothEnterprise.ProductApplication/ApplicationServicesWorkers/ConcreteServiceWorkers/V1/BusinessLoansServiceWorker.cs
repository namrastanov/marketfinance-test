using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers;
using SlothEnterprise.ProductApplication.Products;
using System;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1
{
    internal class BusinessLoansServiceWorker : IApplicationServiceWorker
    {
        private readonly IBusinessLoansService _businessLoansService;

        public BusinessLoansServiceWorker(IServiceProvider serviceProvider)
        {
            _businessLoansService = (IBusinessLoansService)serviceProvider.GetService(typeof(IBusinessLoansService));
        }

        public IApplicationResult SubmitApplication(ISellerApplication application)
        {
            var product = (BusinessLoans)application.Product;
            var result = _businessLoansService.SubmitApplicationFor(
                CompanyDataRequestMapping.MapFromSellerCompanyData(application.CompanyData),
                LoansRequestMapping.MapFromLoansProduct(product));

            return result;
        }

        public bool ValidateApplication(ISellerApplication application)
        {
            // TODO implement validation
            return true;
        }
    }
}
