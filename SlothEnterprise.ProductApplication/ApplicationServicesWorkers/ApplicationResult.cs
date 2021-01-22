using SlothEnterprise.External;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.ApplicationServicesWorkers
{
    public class ApplicationResult : IApplicationResult
    {
        public int? ApplicationId { get; set; }

        public bool Success { get; set; }

        public IList<string> Errors { get; set; }
    }
}
