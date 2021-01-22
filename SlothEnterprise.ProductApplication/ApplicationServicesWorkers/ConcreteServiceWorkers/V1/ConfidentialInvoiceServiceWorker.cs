using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers;
using SlothEnterprise.ProductApplication.Exceptions;
using SlothEnterprise.ProductApplication.Products;
using System;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1
{
    internal class ConfidentialInvoiceServiceWorker : IApplicationServiceWorker
    {
        private readonly IConfidentialInvoiceService _confidentialInvoiceService;

        public ConfidentialInvoiceServiceWorker(IServiceProvider serviceProvider)
        {
            _confidentialInvoiceService = (IConfidentialInvoiceService)serviceProvider.GetService(typeof(IConfidentialInvoiceService));
        }

        public IApplicationResult SubmitApplication(ISellerApplication application)
        {
            var product = (ConfidentialInvoiceDiscount)application.Product;
            var result = _confidentialInvoiceService.SubmitApplicationFor(
                CompanyDataRequestMapping.MapFromSellerCompanyData(application.CompanyData),
                product.TotalLedgerNetworth,
                product.AdvancePercentage,
                product.VatRate);

            return result;
        }

        public IApplicationServiceWorker ValidateApplication(ISellerApplication application)
        {
            // TODO implement full validation

            if (application.CompanyData == null)
            {
                throw new ProductApplicationValidationException("CompanyData could not be null");
            }

            return this;
        }
    }
}
