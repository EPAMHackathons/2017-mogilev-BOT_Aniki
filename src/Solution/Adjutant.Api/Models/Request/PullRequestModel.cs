using System;
using System.Collections.Generic;

namespace Adjutant.Api.Models
{
    public class PullRequestModel : BaseRequestModel
    {
        public int PullRequestId { get; set; }

        public string Alias { get; set; }

        public IEnumerable<string> Labels { get; set; }

        public DateTime StartFrom { get; set; }

        public IEnumerable<string> Users { get; set; }
    }
}
