using Adjutant.Api.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Security.Authentication;

namespace Adjutant.Api.Repositories
{
    public class BotRepository : IBotRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public BotRepository()
        {
            string connectionString = @"mongodb://adjutant:sjXJerLzztR0952kHNkHkmutsjQNrfW5MdCNuNytMrw39T7bxfMOu4XNkFe4E9YlR6RC5PXP2cYTPUNTokObLg==@adjutant.documents.azure.com:10250/?ssl=true&sslverifycertificate=false";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            _client = new MongoClient(settings);
            _database = _client.GetDatabase("Adjutant");
        }

        public string GetRepositoryOwner(string clientId, string alias)
        {
            throw new NotImplementedException();
        }

        public void SaveRepositoryConnection(ConnectRepositoryModel model)
        {
            var collection = _database.GetCollection<BsonDocument>("users");
            var filter = Builders<BsonDocument>.Filter.Eq("clientId", model.ClientId);
            var update = Builders<BsonDocument>.Update
                .Set("alias", $"{model.Alias}")
                .Set("owner", $"{model.Owner}")
                .Set("repositoryname", $"{model.RepositoryName}")
                .Set("repositoryurl", $"{model.RepositoryUrl}")
                .CurrentDate("lastModified");
            var result = collection.UpdateOneAsync(filter, update).Result;
        }
    }
}
