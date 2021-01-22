using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers
{
    internal static class LoansRequestMapping
    {
        public static LoansRequest MapFromLoansProduct(BusinessLoans src)
        {
            return new LoansRequest
            {
                LoanAmount = src.LoanAmount,
                InterestRatePerAnnum = src.InterestRatePerAnnum
            };
        }
    }
}
