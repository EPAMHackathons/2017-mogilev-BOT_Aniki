using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjutant.GitHub
{
    public interface IGitHubService
    {
        string GetIssues(string organizationName, string repositoryName);
    }
}
