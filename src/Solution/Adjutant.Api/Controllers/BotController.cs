using Adjutant.Common.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Adjutant.Api.Controllers
{
    public class BotController : ApiController
    {
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [HttpPost]
        public void ConnectRepository([FromBody]ConnectRepositoryModel model)
        {

        }
    }
}
