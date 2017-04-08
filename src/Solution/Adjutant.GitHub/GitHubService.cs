using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Adjutant.GitHub
{
    public class GitHubService : IGitHubService
    {
        private const string apiUrl = "https://api.github.com/repos";

        public string GetIssues(string organizationName, string repositroyName)
        {
            string getIssuesUrl = string.Format("{0}/{1}/{2}", apiUrl, organizationName, repositroyName);
            var request = WebRequest.Create(getIssuesUrl);
            var response = request.GetResponse();
            var stream = new StreamReader(response.GetResponseStream());

            return stream.ReadToEnd();
        }

        
    }
}
