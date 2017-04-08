using Adjutant.Api.Models;
using Adjutant.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adjutant.Api.Services.Interfaces
{
    public interface IBotService
    {
        void ConnectRepository(string skypeClientId, ConnectRepositoryModel model);

        Task<PullRequestResponseModel> GetPullRequestsAsync(PullRequestModel pullRequestModel);

        Task<StatusResponseModel> GetStatus(StatusRequestModel statusRequestModel);
    }
}
