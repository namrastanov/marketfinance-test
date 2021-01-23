using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers;
using SlothEnterprise.ProductApplication.Exceptions;
using SlothEnterprise.ProductApplication.Products;
using System;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1
{
    internal class ConfidentialInvoiceServiceWorker : BaseApplicationServiceWorker, IApplicationServiceWorker
    {
        private readonly IConfidentialInvoiceService _confidentialInvoiceService;

        public ConfidentialInvoiceServiceWorker(IServiceProvider serviceProvider)
        {
            _confidentialInvoiceService = (IConfidentialInvoiceService)serviceProvider.GetService(typeof(IConfidentialInvoiceService));
        }

        public override IApplicationServiceWorker Submit()
        {
            var product = (ConfidentialInvoiceDiscount)Application.Product;
            ApplicationResult = _confidentialInvoiceService.SubmitApplicationFor(
                CompanyDataRequestMapping.MapFromSellerCompanyData(Application.CompanyData),
                product.TotalLedgerNetworth,
                product.AdvancePercentage,
                product.VatRate);

            return this;
        }

        public override IApplicationServiceWorker Validate()
        {
            // TODO implement full validation

            if (Application.CompanyData == null)
            {
                throw new ProductApplicationValidationException("CompanyData could not be null");
            }

            return this;
        }
    }
}
