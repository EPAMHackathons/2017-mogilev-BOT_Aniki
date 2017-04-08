using NUnit.Framework;

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
        public void GetIssuesTest()
        {
            gitHubService.GetIssues("Azure", "azure-powershell");
        }
    }
}
