using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Exceptions;
using SlothEnterprise.ProductApplication.Products;
using System.Collections.Generic;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests.ProductsApplicationServiceTests
{
    public class ConfidentialInvoiceServiceTests
    {
        private readonly Mock<IConfidentialInvoiceService> _confidentialInvoiceServiceMock = new Mock<IConfidentialInvoiceService>();
        private readonly Mock<IApplicationResult> _successResult = new Mock<IApplicationResult>();
        private readonly Mock<IApplicationResult> _errorsResult = new Mock<IApplicationResult>();

        public ConfidentialInvoiceServiceTests()
        {
            _successResult.SetupProperty(p => p.ApplicationId, 1);
            _successResult.SetupProperty(p => p.Success, true);

            _errorsResult.SetupProperty(p => p.ApplicationId, -1);
            _errorsResult.SetupProperty(p => p.Success, false);
            _errorsResult.SetupProperty(p => p.Errors, new List<string> { "Test Error" });
        }

        [Fact]
        public void ConfidentialInvoiceService_Submit_Succeed()
        {
            _confidentialInvoiceServiceMock.Setup(m =>
                m.SubmitApplicationFor(
                    It.IsAny<CompanyDataRequest>(),
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>()))
                .Returns(_successResult.Object);

            var services = new ServiceCollection();
            services.AddSingleton(typeof(IConfidentialInvoiceService), _confidentialInvoiceServiceMock.Object);
            var serviceProvider = services.BuildServiceProvider();

            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new ConfidentialInvoiceDiscount());
            sellerApplicationMock.SetupProperty(p => p.CompanyData, new SellerCompanyData());
            var sellerApplication = sellerApplicationMock.Object;

            var productApplicationService = new ProductApplicationService(serviceProvider);
            var result = productApplicationService.SubmitApplicationFor(sellerApplication);

            result.Should().Be(1);
        }

        [Fact]
        public void ConfidentialInvoiceService_Submit_Throws_ProductApplicationException()
        {
            _confidentialInvoiceServiceMock.Setup(m =>
                m.SubmitApplicationFor(
                    It.IsAny<CompanyDataRequest>(),
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>()))
                .Returns(_errorsResult.Object);

            var services = new ServiceCollection();
            services.AddSingleton(typeof(IConfidentialInvoiceService), _confidentialInvoiceServiceMock.Object);
            var serviceProvider = services.BuildServiceProvider();

            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, new ConfidentialInvoiceDiscount());
            sellerApplicationMock.SetupProperty(p => p.CompanyData, new SellerCompanyData());
            var sellerApplication = sellerApplicationMock.Object;

            var productApplicationService = new ProductApplicationService(serviceProvider);

            Assert.Throws<ProductApplicationException>(() => productApplicationService.SubmitApplicationFor(sellerApplication));
        }
    }
}