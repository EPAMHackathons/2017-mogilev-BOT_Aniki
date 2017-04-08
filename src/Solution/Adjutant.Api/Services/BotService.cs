using System;
using System.Collections.Generic;
using Adjutant.Api.Models;
using Adjutant.Api.Services.Interfaces;
using Adjutant.Api.Repositories;
using Adjutant.GitHub;

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

        public IEnumerable<PullRequestResponseModel> GetPullRequests(PullRequestModel pullRequestModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusResponseModel> GetStatus()
        {
            throw new NotImplementedException();
        }
    }
}
