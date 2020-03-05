using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scaffold.Shared.ContractResolvers;
using System.Net;
using System.Threading.Tasks;

namespace Scaffold.Application.Results
{
    public abstract class AbstractApiResult : IActionResult
    {
        protected const string Success = "success";
        protected const string Failure = "failure";

        public HttpStatusCode Code { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)Code;
            context.HttpContext.Response.ContentType = "application/json";
            await new ObjectResult(this.Data).ExecuteResultAsync(context);
        }

        public bool ShouldSerializeCode() => false;
        public bool ShouldSerializeStatus() => false;

        public string ToJson() => JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        });
    }
}
