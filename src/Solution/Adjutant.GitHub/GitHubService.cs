using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Octokit;

namespace Adjutant.GitHub
{
    public class GitHubService : IGitHubService
    {
        private const string apiUrl = "https://api.github.com/repos";

        private GitHubClient client;

        public GitHubService()
        {
            client = new GitHubClient(new Octokit.ProductHeaderValue("Adjutant"), new Uri(apiUrl));

            client.Credentials = new Credentials("Darya_Tselesh@epam.com", "q1w2e3r4t5");
        }

        public async Task<IEnumerable<Issue>> GetIssuesAsync(string organizationName, string repositroyName)
        {
            return await client.Issue.GetAllForRepository(organizationName, repositroyName);
        }

        public async Task<IEnumerable<Label>> GetLabelsAsync(string organizationName, string repositroyName)
        {
            IEnumerable<Issue> issues = await this.GetIssuesAsync(organizationName, repositroyName);
            List<Label> labels = new List<Label>();

            foreach(Issue issue in issues)
            {
                labels.AddRange(issue.Labels);
            }

            return labels;
        }

        public async Task<IEnumerable<PullRequest>> GetPullRequestAsync(
            string organizationName,
            string repositroyName,
            IEnumerable<string> userLogins = null,
            TimeSpan? timePeriod = null, 
            long? id = null)
        {
            IEnumerable<PullRequest> pullRequests = await client.PullRequest.GetAllForRepository(organizationName, repositroyName);

            if (pullRequests != null && id != null)
            {
                pullRequests = pullRequests.Where(pullRequest => pullRequest.Id == id);
            }

            if (pullRequests != null && userLogins != null && userLogins.Any())
            {
                pullRequests = pullRequests.Where(pullRequest => userLogins.Contains(pullRequest.User.Login));
            }

            if (pullRequests != null && timePeriod != null)
            {
                pullRequests = pullRequests.Where(pullRequest => pullRequest.CreatedAt.DateTime >= (DateTime.UtcNow - timePeriod));
            }

            return pullRequests;
        }
    }


}
