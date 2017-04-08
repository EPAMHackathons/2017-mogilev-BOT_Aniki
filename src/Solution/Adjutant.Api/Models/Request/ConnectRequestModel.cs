namespace Adjutant.Api.Models
{
    public class ConnectRequestModel : BaseRequestModel
    {
        public string RepositoryUrl { get; set; }

        public string RepositoryName { get; set; }

        public string Owner { get; set; }

        public string Alias { get; set; }
    }
}