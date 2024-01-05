using Agada.Models;
using NUnit.Framework;

namespace Agada.Tests
{
    public class AgadaClientTests
    {
        [Test]
        public void TestAgadaClientConstructor()
        {
            var options = new AgadaOptions
            {
                Culture = "en-US",
                ApiKey = "api-key",
                BaseUrl = "https://gate.agada.com",
                ChannelName = "test-client",
            };
            var client = new AgadaClient(options);
            Assert.NotNull(client.Adm);
            Assert.NotNull(client.Hub);
            Assert.NotNull(client.Game);
            Assert.NotNull(client.Promotion);
            Assert.NotNull(client.SmartDeals);
        }
    }
}