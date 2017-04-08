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
        }

        public async Task<IEnumerable<Issue>> GetIssuesAsync(string organizationName, string repositroyName)
        {
            return await client.Issue.GetAllForRepository(organizationName, repositroyName);
        }


    }


}
