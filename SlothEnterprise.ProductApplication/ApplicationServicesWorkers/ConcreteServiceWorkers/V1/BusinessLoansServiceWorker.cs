using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers;
using SlothEnterprise.ProductApplication.Exceptions;
using SlothEnterprise.ProductApplication.Products;
using System;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1
{
    internal class BusinessLoansServiceWorker : BaseApplicationServiceWorker, IApplicationServiceWorker
    {
        private readonly IBusinessLoansService _businessLoansService;

        public BusinessLoansServiceWorker(IServiceProvider serviceProvider)
        {
            _businessLoansService = (IBusinessLoansService)serviceProvider.GetService(typeof(IBusinessLoansService));
        }

        public override IApplicationServiceWorker Submit()
        {
            var product = (BusinessLoans)Application.Product;
            ApplicationResult = _businessLoansService.SubmitApplicationFor(
                CompanyDataRequestMapping.MapFromSellerCompanyData(Application.CompanyData),
                LoansRequestMapping.MapFromLoansProduct(product));

            return this;
        }

        public override IApplicationServiceWorker Validate()
        {
            // TODO implement full validation

            var product = (BusinessLoans)Application.Product;
            if (product.Id > 0)
            {
                throw new ProductApplicationValidationException("BusinessLoan's Id is not specified");
            }

            return this;
        }
    }
}
