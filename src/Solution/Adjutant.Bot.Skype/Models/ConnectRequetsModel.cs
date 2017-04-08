namespace Adjutant.Bot.Skype.Models
{
    public class ConnectRequetsModel : BaseEntity
    {
        public long ClientId { get; set; }

        public string RepositoryUrl { get; set; }

        public string Alias { get; set; }

        public string Owner { get; set; }

        public string RepositoryName { get; set; }
    }
}