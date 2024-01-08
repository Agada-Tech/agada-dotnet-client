using Agada.Constants;
using Agada.Models;
using NUnit.Framework;

namespace Agada.Tests
{
    public class AgadaClientTests
    {
        [Test]
        public void TestAgadaClientConstructor()
        {
            var options = new AgadaOptions(AgadaEnvironment.Sandbox, "api-key", "en-US", "test-client");
            var client = new AgadaClient(options);
            Assert.NotNull(client.Adm);
            Assert.NotNull(client.Hub);
            Assert.NotNull(client.Game);
            Assert.NotNull(client.Promotion);
            Assert.NotNull(client.SmartDeals);
        }
    }
}