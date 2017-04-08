using NUnit.Framework;
using Octokit;
using System.Collections.Generic;

namespace Adjutant.GitHub.Tests
{
    /// <summary>
    /// Summary description for GitHubServiceTests
    /// </summary>
    [TestFixture]
    public class GitHubServiceTests
    {
        private GitHubService gitHubService;

        [SetUp]
        public void SetUp()
        {
            gitHubService = new GitHubService();
        }

        [Test]
        public async System.Threading.Tasks.Task GetIssuesTestAsync()
        {
            IEnumerable<Issue> issues = await gitHubService.GetIssuesAsync("Azure", "azure-powershell");
            Assert.IsNotNull(issues);
        }
    }


}
