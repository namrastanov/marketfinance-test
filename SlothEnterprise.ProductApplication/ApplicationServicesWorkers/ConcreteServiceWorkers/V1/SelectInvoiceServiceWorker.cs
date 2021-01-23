using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Exceptions;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1
{
    internal class SelectInvoiceServiceWorker : BaseApplicationServiceWorker, IApplicationServiceWorker
    {
        private readonly ISelectInvoiceService _selectInvoiceService;

        public SelectInvoiceServiceWorker(IServiceProvider serviceProvider)
        {
            _selectInvoiceService = (ISelectInvoiceService)serviceProvider.GetService(typeof(ISelectInvoiceService));
        }

        public override IApplicationServiceWorker Submit()
        {
            var product = (SelectiveInvoiceDiscount)Application.Product;
            var applicationId = _selectInvoiceService.SubmitApplicationFor(
                Application.CompanyData.Number.ToString(),
                product.InvoiceAmount,
                product.AdvancePercentage);

            ApplicationResult = new ApplicationResult
            {
                ApplicationId = applicationId,
                Success = applicationId > 0,
                Errors = new List<string> { }
            };

            return this;
        }

        public override IApplicationServiceWorker Validate()
        {
            // TODO implement detailed validation

            if (Application.CompanyData.Number == 0)
            {
                throw new ProductApplicationValidationException("CompanyData.Number could not be 0");
            }

            return this;
        }
    }
}
