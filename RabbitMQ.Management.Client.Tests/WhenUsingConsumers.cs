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
    public class WhenUsingConsumers: TestBase
    {
        [Theory]
        [JsonFileData("Data/consumers.json")]
        public async Task ShouldRetrieveAListOfConsumersForVhost(string returnValue)
        {
            //Arrange
            var vHost = "foo";
            var expectedUri = new Uri($"http://test.com/api/consumers/{vHost}");
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var result = await client.GetConsumers(vHost);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(397);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }
    }
}