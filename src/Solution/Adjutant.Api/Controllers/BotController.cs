using Adjutant.Api.Models;
using Adjutant.Api.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Adjutant.Api.Repositories;
using Newtonsoft.Json;

namespace Adjutant.Api.Controllers
{
    public class BotController : ApiController
    {
        private BotService botService;

        public BotController()
        {
            botService = new BotService();
        }

        [SwaggerOperation("ConnectRepository")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        [Route("github/connect")]
        public Task<HttpResponseMessage> SetConnectRepository([FromBody]ConnectRequestModel model)
        {
            var response = new HttpResponseMessage();
            var connectRepositoryModel = new ConnectRepositoryModel()
            {
                Alias = model.Alias,
                ClientId = model.ClientId,
                Owner = model.Owner,
                RepositoryName = model.RepositoryName,
                RepositoryUrl = model.RepositoryUrl
            };

            try
            {
                botService.ConnectRepository(model.ClientId.ToString(), connectRepositoryModel);
            }
            catch
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            response.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(response);
        }

        [SwaggerOperation("GetStatus")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        [Route("github/status")]
        public async Task<HttpResponseMessage> GetStatusAsync([FromBody]StatusRequestModel model)
        {
            var response = new HttpResponseMessage();
            StatusResponseModel status = null;

            try
            {
                status = await botService.GetStatus(model);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(JsonConvert.SerializeObject(status));

            return response;
        }

        [SwaggerOperation("GetPullRequests")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpPost]
        [Route("github/pullrequest")]
        public async Task<HttpResponseMessage> GetPullRequests([FromBody]PullRequestModel model)
        {
            var response = new HttpResponseMessage();
            PullRequestResponseModel pullRequest = null;

            try
            {
                pullRequest = await botService.GetPullRequestsAsync(model);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(JsonConvert.SerializeObject(pullRequest));

            return response;
        }
    }
}
