using NUnit.Framework;
using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Adjutant.GitHub.Tests
{
    /// <summary>
    /// Summary description for GitHubServiceTests
    /// </summary>
    [TestFixture]
    public class GitHubServiceTests
    {
        private const string CompanyName = "Azure";

        private const string ReposirotyName = "azure-powershell";

        private GitHubService gitHubService;

        [SetUp]
        public void SetUp()
        {
            gitHubService = new GitHubService();
        }

        [Test]
        public async Task GetIssuesTestAsync()
        {
            IEnumerable<Issue> issues = await gitHubService.GetIssuesAsync(CompanyName, ReposirotyName);
            Assert.IsNotNull(issues);
        }

        [Test]
        public async Task GetLabelsTestAsync()
        {
            IEnumerable<Label> labels = await gitHubService.GetLabelsAsync(CompanyName, ReposirotyName);
            Assert.IsNotNull(labels);
        }

        [Test]
        public async Task GetPullRequestsByTimePeriodTestAsync()
        {
            IEnumerable<PullRequest> pullRequests = await gitHubService.GetPullRequestAsync(CompanyName, ReposirotyName, timePeriod: new TimeSpan(5, 0, 0, 0));
            Assert.AreEqual(pullRequests.Count(), 4);
        }

        [Test]
        public async Task GetPullRequestsByUserTestAsync()
        {
            var userLogins = new List<string>();

            userLogins.Add("viananth");
            userLogins.Add("v-Ajnava");

            IEnumerable<PullRequest> pullRequests = await gitHubService.GetPullRequestAsync(CompanyName, ReposirotyName, userLogins: userLogins);
            Assert.AreEqual(pullRequests.Count(), 2);
        }

        [Test]
        public async Task GetPullRequestsByIdTestAsync()
        {
            IEnumerable<PullRequest> pullRequests = await gitHubService.GetPullRequestAsync(CompanyName, ReposirotyName, id: 114896918);
            Assert.AreEqual(pullRequests.Count(), 1);
        }

        [Test]
        public async Task GetPullRequestsByAllFiltersAsync()
        {
            var userLogins = new List<string>();

            userLogins.Add("viananth");
            userLogins.Add("v-Ajnava");

            IEnumerable<PullRequest> pullRequests = await gitHubService.GetPullRequestAsync(CompanyName, ReposirotyName, userLogins, new TimeSpan(5, 0, 0, 0), 114896918);
            Assert.AreEqual(pullRequests.Count(), 1);
        }
    }


}
