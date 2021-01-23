using SlothEnterprise.External;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers
{
    /// <summary>
    /// Implementation of IApplicationResult
    /// Needed for the workers which cover services without such a result in the response
    /// </summary>
    public class ApplicationResult : IApplicationResult
    {
        public int? ApplicationId { get; set; }

        public bool Success { get; set; }

        public IList<string> Errors { get; set; }
    }
}
