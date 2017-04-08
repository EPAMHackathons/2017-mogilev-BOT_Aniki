using NUnit.Framework;
using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }


}
