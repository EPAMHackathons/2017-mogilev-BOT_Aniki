using System.Collections.Generic;

namespace Adjutant.Api.Repositories.Interfaces
{
    public interface IBotRepository
    {
        void SaveRepositoryConnection(ConnectRepositoryModel model);

        KeyValuePair<string, string> GetRepositoryOwner(string clientId, string alias);
    }
}
