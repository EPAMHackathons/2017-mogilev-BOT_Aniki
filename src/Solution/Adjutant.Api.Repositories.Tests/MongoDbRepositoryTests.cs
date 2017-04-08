using Adjutant.Api.Repositories.Interfaces;
using NUnit.Framework;
using System;

namespace Adjutant.Api.Repositories.Tests
{
    [TestFixture]
    public class MongoDbRepositoryTests
    {
        [Test]
        public void DatabaseTest()
        {
            var instance = new BotRepository();
            long clientId = 12345;
            var model = new ConnectRepositoryModel();
            model.Alias = "alias";
            model.ClientId = clientId;
            model.Owner = "owner";
            model.RepositoryName = "azure";
            model.RepositoryUrl = "https://github.com/EPAMHackathons/2017-mogilev-BOT_Aniki";

            instance.SaveRepositoryConnection(model);
        }
    }
}
