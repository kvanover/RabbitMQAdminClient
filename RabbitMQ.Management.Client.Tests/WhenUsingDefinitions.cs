using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace RabbitMQ.Management.Client.Tests
{
    public class WhenUsingDefinitions
    {
        [Fact]
        public async Task ShouldRetrieveDefinitionsForAll()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            var definitions = await client.GetDefinitions();

            definitions.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldRetrieveDefinitionsForVHost()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            var definitions = await client.GetDefinitions("/");

            definitions.Should().NotBeNull();
        }
    }
}