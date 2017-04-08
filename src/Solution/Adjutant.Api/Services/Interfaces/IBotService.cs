using Adjutant.Api.Models;
using Adjutant.Api.Repositories;
using System.Collections.Generic;

namespace Adjutant.Api.Services.Interfaces
{
    public interface IBotService
    {
        void ConnectRepository(string skypeClientId, ConnectRepositoryModel model);

        IEnumerable<PullRequestResponseModel> GetPullRequests(PullRequestModel pullRequestModel);

        IEnumerable<StatusResponseModel> GetStatus();
    }
}
