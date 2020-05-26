using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using RabbitMQ.Management.Client.Models;
using Xunit;

namespace RabbitMQ.Management.Client.Tests
{
    public class WhenUsingNodes
    {
        [Fact]
        public async Task ShouldRetrieveAListOfAllNodes()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            var nodes = await client.GetNodes(QueryOrder.Ascending, node => node.Name, PropertyFilters<RabbitMqNode>.Build().AddFilter(x => x.Name).AddFilter(x => x.Contexts), CancellationToken.None);

            nodes.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldRetrieveASingleNode()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            var nodes = await client.GetNodes();

            foreach (var node in nodes)
            {
                var expectedNode = await client.GetNode(node.Name, true, true, CancellationToken.None);

                expectedNode.Should().NotBeNull();
            }
        }
    }
}