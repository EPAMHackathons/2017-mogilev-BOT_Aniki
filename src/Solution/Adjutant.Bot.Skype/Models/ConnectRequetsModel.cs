using System.Collections.Generic;
using System.Security.Policy;

namespace Adjutant.Bot.Skype.Models
{
	public class ConnectRequetsModel : BaseEntity
	{
		public long ClientId { get; set; }

		public Url RepositoryUrl { get; set; }

		public string Alias { get; set; }

		public string Owner { get; set; }

		public string RepositoryName { get; set; }

		public int TimePeriod { get; set; }

		public IList<string> Users { get; set; }

        public int iDUserPrid { get; set; }
    }
}