using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjutant.Api.Models
{
    public class StatusResponseModel
    {
        public IEnumerable<PullRequest> PullRequests { get; set; }

        public IEnumerable<Issue> Issues { get; set; }
    }
}
