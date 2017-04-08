namespace Adjutant.Api.Repositories
{
    public class ConnectRepositoryModel
    {
        public long ClientId { get; set; }

        public string RepositoryUrl { get; set; }

        public string RepositoryName { get; set; }

        public string Owner { get; set; }

        public string Alias { get; set; }
    }
}
