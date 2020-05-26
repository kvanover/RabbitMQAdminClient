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
    public class WhenUsingChannels : TestBase
    {
        [Theory]
        [JsonFileData("Data/connectionChannels.json")]
        public async Task ShouldRetrieveAListOfChannelsForConnection(string returnValue)
        {
            //Arrange
            var connectionName = "foo";
            var expectedUri = new Uri($"http://test.com/api/connections/{connectionName}/channels");
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var result = await client.GetChannelsForConnection(connectionName);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(10);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Theory]
        [JsonFileData("Data/channels.json")]
        public async Task ShouldRetrieveListOfChannels(string returnValue)
        {
            //Arrange
            var expectedUri = new Uri("http://test.com/api/channels");
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var result = await client.GetOpenChannels();

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(601);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Theory]
        [JsonFileData("Data/channel.json")]
        public async Task ShouldRetrieveAChannelOnName(string returnValue)
        {
            //Arrange
            var channelName = "foo";
            var expectedUri = new Uri($"http://test.com/api/channels/{channelName}");
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var result = await client.GetChannel(channelName);

            //Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(channelName);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task ShouldThrowWhenNameIsMalformed(string channelName)
        {
            //Arrange
            var client = new RabbitMQAdminClient(new Mock<HttpClient>().Object, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            Func<Task> action = async () => await client.GetChannel(channelName);

            //Assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}