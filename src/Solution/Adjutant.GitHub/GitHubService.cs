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

        private const string token = "3abaff4e9069423d1bf678c79478e2b890e14d7a";

        private GitHubClient client;

        public GitHubService()
        {
            client = new GitHubClient(new Octokit.ProductHeaderValue("Adjutant"), new Uri(apiUrl));

            client.Credentials = new Credentials(token);
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


    }


}
