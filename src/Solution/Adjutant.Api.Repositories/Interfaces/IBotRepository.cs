namespace Adjutant.Api.Repositories.Interfaces
{
    public interface IBotRepository
    {
        void SaveRepositoryConnection(ConnectRepositoryModel model);

        string GetRepositoryOwner(string clientId, string alias);
    }
}
