using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication
{
    /// <summary>
    /// Provides method for submitting application for any type of product
    /// </summary>
    public interface IProductApplicationService
    {
        /// <summary>
        /// Submits the application and returns the Application Id
        /// </summary>
        /// <param name="application">ISellerApplication instance</param>
        /// <returns>Application Id | -1 if errors</returns>
        int SubmitApplicationFor(ISellerApplication application);
    }
}