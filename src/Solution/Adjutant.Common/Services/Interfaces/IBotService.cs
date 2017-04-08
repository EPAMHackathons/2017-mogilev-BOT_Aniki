using Adjutant.Common.Models;

namespace Adjutant.Common.Services.Interfaces
{
    public interface IBotService
    {
        void ConnectRepository(string skypeClientId, ConnectRepositoryModel model);
    }
}
