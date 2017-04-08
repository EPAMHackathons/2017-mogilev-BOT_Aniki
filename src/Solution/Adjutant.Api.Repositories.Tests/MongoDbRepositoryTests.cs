using Adjutant.Api.Repositories.Interfaces;
using NUnit.Framework;
using System;

namespace Adjutant.Api.Repositories.Tests
{
    [TestFixture]
    public class MongoDbRepositoryTests
    {
        [Test]
        public void SaveRepositoryConnectionTest()
        {
            var instance = new BotRepository();
            long clientId = 123456;
            var model = new ConnectRepositoryModel();
            model.Alias = "alias";
            model.ClientId = clientId;
            model.Owner = "owner";
            model.RepositoryName = "azure";
            model.RepositoryUrl = "https://github.com/EPAMHackathons/2017-mogilev-BOT_Aniki";

            instance.SaveRepositoryConnection(model);
        }

        [Test]
        public void GetRepositoryOwnerTest()
        {
            var instance = new BotRepository();
            string clientId = "123456";

            var owner = instance.GetRepositoryOwner(clientId, "alias");
        }
    }
}
