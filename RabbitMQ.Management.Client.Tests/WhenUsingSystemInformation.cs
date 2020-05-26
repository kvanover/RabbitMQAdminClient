using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace RabbitMQ.Management.Client.Tests
{
    public class WhenUsingSystemInformation
    {
        [Fact]
        public async Task ShouldRetrieveInformation()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            var systemOverview = await client.GetSystemOverview(CancellationToken.None);

            systemOverview.Should().NotBeNull();
        }
    }
}