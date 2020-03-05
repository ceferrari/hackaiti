using System.Collections.Generic;
using System.Net;

namespace Scaffold.Application.Results
{
    public class FailureApiResult : AbstractApiResult
    {
        public FailureApiResult(HttpStatusCode code, IList<string> data)
        {
            Code = code;
            Status = Failure;
            Data = data;
        }

        public FailureApiResult(HttpStatusCode code, string data)
        {
            Code = code;
            Status = Failure;
            Data = new List<string>() { data };
        }
    }
}
