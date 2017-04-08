using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Adjutant.Api.Models
{
    public class PullRequestResponseModel
    {
        public IEnumerable<PullRequest> PullRequests { get; set; }
    }
}
