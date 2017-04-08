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

        private BotRepository repository = null;

        public BotService()
        {
            gitHubService = new GitHubService();
            repository = new BotRepository();
        }
        public void ConnectRepository(string skypeClientId, ConnectRepositoryModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<PullRequestResponseModel> GetPullRequestsAsync(PullRequestModel pullRequestModel)
        {
            var pullRequestResponseModel = new PullRequestResponseModel();
            var repositoryOwner = repository.GetRepositoryOwner(pullRequestModel.ClientId.ToString(), pullRequestModel.Alias);

            pullRequestResponseModel.PullRequests = await gitHubService.GetPullRequestAsync(repositoryOwner.Key, repositoryOwner.Value, pullRequestModel.Users, pullRequestModel.StartFrom, pullRequestModel.PullRequestId);
            
            return pullRequestResponseModel;
        }

        public async Task<StatusResponseModel> GetStatus(StatusRequestModel statusRequestModel)
        {
            var statusResponseModel = new StatusResponseModel();
            var ownerRepository = repository.GetRepositoryOwner(statusRequestModel.ClientId.ToString(), statusRequestModel.Alias);

            statusResponseModel.PullRequests = await gitHubService.GetPullRequestAsync(ownerRepository.Key, ownerRepository.Value, statusRequestModel.Users, statusRequestModel.StartFrom);
            statusResponseModel.Issues = await gitHubService.GetIssuesAsync(ownerRepository.Key, ownerRepository.Value, statusRequestModel.Users, statusRequestModel.StartFrom);

            return statusResponseModel;
        }
    }
}
