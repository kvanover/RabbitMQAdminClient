using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

namespace RabbitMQ.Management.Client.Tests
{
    public class WhenUsingConnections : TestBase
    {
        [Theory]
        [JsonFileData("Data/allConnections.json")]
        public async Task ShouldRetrieveListOfConnections(string returnValue)
        {
            //Arrange
            var expectedUri = new Uri("http://test.com/api/connections");
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var result = await client.GetConnections();

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(127);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Theory]
        [JsonFileData("Data/allConnections.json")]
        public async Task ShouldRetrieveListOfConnectionsWithVHost(string returnValue)
        {
            //Arrange
            var vhost = "vhost01";
            var expectedUri = new Uri($"http://test.com/api/vhosts/{vhost}/connections");
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var result = await client.GetConnections(vhost);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCountLessOrEqualTo(127);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Theory]
        [JsonFileData("Data/connection.json")]
        public async Task ShouldRetrieveAConnectionOnName(string returnValue)
        {
            //Arrange
            var connectionName = "35.35.53.53:34137 -> 10.56.72.2:5671";
            var expectedUri = new Uri($"http://test.com/api/connections/{connectionName}");
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var result = await client.GetConnection(connectionName);

            //Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(connectionName);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task ShouldThrowWhenNameIsMalformed(string connectionName)
        {
            //Arrange
            var client = new RabbitMQAdminClient(new Mock<HttpClient>().Object, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            Func<Task> action  = async () => await client.GetConnection(connectionName);

            //Assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}