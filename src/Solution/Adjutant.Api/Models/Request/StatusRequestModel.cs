using System;
using System.Collections.Generic;

namespace Adjutant.Api.Models
{
    public class StatusRequestModel : BaseRequestModel
    {
        public string Alias { get; set; }

        public string RepositoryUrl { get; set; }

        public DateTime StartFrom { get; set; }

        public List<string> Users { get; set; }
    }
}
