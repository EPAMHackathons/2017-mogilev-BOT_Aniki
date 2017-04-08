using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjutant.GitHub
{
    public interface IGitHubService
    {
        Task<IEnumerable<Issue>> GetIssuesAsync(string organizationName, string repositroyName);

        Task<IEnumerable<Label>> GetLabelsAsync(string organizationName, string repositroyName);

        Task<IEnumerable<PullRequest>> GetPullRequestAsync(
            string organizationName,
            string repositroyName,
            IEnumerable<string> userLogins = null,
            TimeSpan? timePeriod = null,
            long? id = null);
    }
}
