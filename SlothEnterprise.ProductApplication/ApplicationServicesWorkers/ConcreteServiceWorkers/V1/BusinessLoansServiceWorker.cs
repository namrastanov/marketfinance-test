using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers;
using SlothEnterprise.ProductApplication.Exceptions;
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

        public IApplicationServiceWorker ValidateApplication(ISellerApplication application)
        {
            // TODO implement full validation

            var product = (BusinessLoans)application.Product;
            if (product.Id > 0)
            {
                throw new ProductApplicationValidationException("BusinessLoan's Id is not specified");
            }

            return this;
        }
    }
}
