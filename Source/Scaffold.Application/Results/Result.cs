using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scaffold.Shared.ContractResolvers;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Scaffold.Application.Results
{
    public abstract class Result : IActionResult
    {
        protected const string Success = "success";
        protected const string Failure = "failure";

        public HttpStatusCode Code { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }
        public ResultError Error { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)Code;
            context.HttpContext.Response.ContentType = "application/json";
            await new ObjectResult(this).ExecuteResultAsync(context);
        }

        public bool ShouldSerializeCode() => false;
        public bool ShouldSerializeData() => Success.Equals(Status);
        public bool ShouldSerializeError() => Failure.Equals(Status);

        public string ToJson() => JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        });

        public class ResultError
        {
            public ResultError(string message, IList<string> details)
            {
                Message = message;
                Details = details;
            }

            public string Message { get; set; }
            public IList<string> Details { get; set; }
        }
    }

    public class SuccessResult : Result
    {
        public SuccessResult(HttpStatusCode code, object data)
        {
            Code = code;
            Status = Success;
            Data = data;
        }
    }

    public class FailureResult : Result
    {
        public FailureResult(HttpStatusCode code, string errorMessage, IList<string> errorDetails)
        {
            Code = code;
            Status = Failure;
            Error = new ResultError(errorMessage, errorDetails);
        }
    }
}
