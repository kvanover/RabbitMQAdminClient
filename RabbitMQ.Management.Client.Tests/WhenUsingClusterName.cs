using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace RabbitMQ.Management.Client.Tests
{
    public class WhenUsingClusterName
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldFailOnMalformedClusterName(string clusterName)
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);
            Func<Task> actionToTest = async () => await client.ChangeClusterName(clusterName, CancellationToken.None);

            await actionToTest.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task ShouldGetName()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            var clusterName = await client.GetClusterName(CancellationToken.None);

            clusterName.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldChangeName()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);
            var newClusterName = "john@doe";

            var oldClusterName = await client.GetClusterName(CancellationToken.None);

            oldClusterName.Should().NotBe(newClusterName);

            await client.ChangeClusterName(newClusterName);

            var currentClusterName = await client.GetClusterName(CancellationToken.None);

            currentClusterName.Should().Be(newClusterName);

            await client.ChangeClusterName(oldClusterName);
        }
    }
}