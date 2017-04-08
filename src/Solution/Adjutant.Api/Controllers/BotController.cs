using Adjutant.Api.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adjutant.Api.Controllers
{
    public class BotController : ApiController
    {
        [SwaggerOperation("ConnectRepository")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        [Route("github/connect")]
        public Task<HttpResponseMessage> SetConnectRepository([FromBody]ConnectRequestModel model)
        {
            throw new NotImplementedException();

            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };

            return Task.FromResult(response);
        }

        [SwaggerOperation("GetStatus")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        [Route("github/status")]
        public Task<HttpResponseMessage> GetStatus([FromBody]StatusRequestModel model)
        {
            throw new NotImplementedException();

            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };

            return Task.FromResult(response);
        }

        [SwaggerOperation("GetPullRequests")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        [Route("github/pullrequest")]
        public Task<HttpResponseMessage> GetPullRequests([FromBody]PullRequestModel model)
        {
            throw new NotImplementedException();

            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };

            return Task.FromResult(response);
        }
    }
}
