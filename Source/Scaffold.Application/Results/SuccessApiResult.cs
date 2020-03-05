using System.Net;

namespace Scaffold.Application.Results
{
    public class SuccessApiResult : AbstractApiResult
    {
        public SuccessApiResult(HttpStatusCode code, object data)
        {
            Code = code;
            Status = Success;
            Data = data;
        }
    }
}
