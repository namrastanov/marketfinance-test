using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers;
using SlothEnterprise.ProductApplication.Exceptions;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1
{
    internal class SelectInvoiceServiceWorker : IApplicationServiceWorker
    {
        private readonly ISelectInvoiceService _selectInvoiceService;

        public SelectInvoiceServiceWorker(IServiceProvider serviceProvider)
        {
            _selectInvoiceService = (ISelectInvoiceService)serviceProvider.GetService(typeof(ISelectInvoiceService));
        }

        public IApplicationResult SubmitApplication(ISellerApplication application)
        {
            var product = (SelectiveInvoiceDiscount)application.Product;
            var applicationId = _selectInvoiceService.SubmitApplicationFor(
                application.CompanyData.Number.ToString(),
                product.InvoiceAmount,
                product.AdvancePercentage);

            var result = new ApplicationResult
            {
                ApplicationId = applicationId,
                Success = applicationId > 0,
                Errors = new List<string> { }
            };

            return result;
        }

        public IApplicationServiceWorker ValidateApplication(ISellerApplication application)
        {
            // TODO implement full validation

            if (application.CompanyData.Number == 0)
            {
                throw new ProductApplicationValidationException("CompanyData.Number could not be 0");
            }

            return this;
        }
    }
}
