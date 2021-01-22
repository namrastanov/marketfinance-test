using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers.ConcreteServiceWorkers.V1.Mappers
{
    internal static class CompanyDataRequestMapping
    {
        public static CompanyDataRequest MapFromSellerCompanyData(ISellerCompanyData src)
        {
            return new CompanyDataRequest
            {
                CompanyFounded = src.Founded,
                CompanyName = src.Name,
                CompanyNumber = src.Number,
                DirectorName = src.DirectorName
            };
        }
    }
}
