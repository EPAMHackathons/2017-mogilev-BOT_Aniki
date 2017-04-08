using System;
using System.Collections.Generic;
using Adjutant.Api.Models;
using Adjutant.Api.Services.Interfaces;
using Adjutant.Api.Repositories;
using Adjutant.GitHub;
using System.Threading.Tasks;

namespace Adjutant.Api.Services
{
    public class BotService : IBotService
    {
        private GitHubService gitHubService = null;

        public BotService()
        {
            gitHubService = new GitHubService();
        }
        public void ConnectRepository(string skypeClientId, ConnectRepositoryModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<PullRequestResponseModel> GetPullRequestsAsync(PullRequestModel pullRequestModel)
        {
            var pullRequestResponseModel = new PullRequestResponseModel();
            //TODO: get organization and repostiory name
            pullRequestResponseModel.PullRequests = await gitHubService.GetPullRequestAsync("", "", pullRequestModel.Users, pullRequestModel.StartFrom, pullRequestModel.PullRequestId);

            return pullRequestResponseModel;
        }

        public async Task<StatusResponseModel> GetStatus(StatusRequestModel statusRequestModel)
        {
            var statusResponseModel = new StatusResponseModel();
            //TODO: get organization and repostiory name
            statusResponseModel.PullRequests = await gitHubService.GetPullRequestAsync("", "", statusRequestModel.Users, statusRequestModel.StartFrom);
            statusResponseModel.Issues = await gitHubService.GetIssuesAsync("", "", statusRequestModel.Users, statusRequestModel.StartFrom);
            return statusResponseModel;
        }
    }
}
