using Adjutant.Api.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public KeyValuePair<string, string> GetRepositoryOwner(string clientId, string alias)
        {
            var collection = _database.GetCollection<UserEntity>("users");
            var filter = Builders<UserEntity>.Filter.Eq("ClientId", clientId);
            UserEntity user = collection.Find(filter).ToListAsync().Result.First();

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var repository = user.Repositories.First(_ => _.Alias.ToUpperInvariant() == alias.ToUpperInvariant());

            if (repository == null && string.IsNullOrWhiteSpace(repository.Owner))
            {
                throw new Exception("Repository not found.");
            }

            return new KeyValuePair<string, string>(repository.Owner, repository.RepositoryName);
        }

        public void SaveRepositoryConnection(ConnectRepositoryModel model)
        {
            var collection = _database.GetCollection<UserEntity>("users");
            var filter = Builders<UserEntity>.Filter.Eq("ClientId", model.ClientId);
            UserEntity user = collection.Find(filter).ToListAsync().Result.FirstOrDefault();

            if (user == null)
            {
                user = new UserEntity();
                user.ClientId = model.ClientId;
            }
            else
            {
                if (user.Repositories.Any(_ => _.Alias == model.Alias))
                {
                    throw new Exception("Alias already exist.");
                }
            }

            user.Repositories.Add(new RepositoryEntity
            {
                Alias = model.Alias,
                Owner = model.Owner,
                RepositoryName = model.RepositoryName,
                RepositoryUrl = model.RepositoryUrl
            });

            collection.ReplaceOneAsync(p => p._id == user._id, user, new UpdateOptions { IsUpsert = true });
        }
    }

    public class UserEntity
    {
        public UserEntity()
        {
            Repositories = new List<RepositoryEntity>();
        }

        [BsonId]
        public int _id { get; set; }

        public long ClientId { get; set; }

        [BsonIgnoreIfNull]
        public IList<RepositoryEntity> Repositories { get; set; }
    }

    public class RepositoryEntity
    {
        public string Alias { get; set; }

        public string Owner { get; set; }

        public string RepositoryName { get; set; }

        public string RepositoryUrl { get; set; }
    }
}
