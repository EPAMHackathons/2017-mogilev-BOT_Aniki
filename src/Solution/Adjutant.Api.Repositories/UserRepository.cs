using Adjutant.Common.Models;

namespace Adjutant.Api.Repositories.Interfaces
{
    public interface IBotRepository
    {
        void SaveRepositoryConnection(string clientId, ConnectRepositoryModel model);
    }
}
