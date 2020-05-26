using System;
using System.Linq;
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
    public class WhenUsingExtensions : TestBase
    {
        [Fact]
        public async Task ShouldRetrieveAListOfAllNodes()
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            var extensions = await client.GetExtensions(CancellationToken.None);

            var keyValuePairs = extensions.ToList();
            keyValuePairs.Should().NotBeNull();
            keyValuePairs.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Fact]
        public async Task ShouldRetrieveListOfAllNodes()
        {
            //Arrange
            var expectedUri = new Uri("http://test.com/api/extensions");
            var returnValue = "[{\"javascript\": \"dispatcher.js\"},{\"javascript\": \"federation.js\"},{\"javascript\": \"shovel.js\"}]";
            var handlerMock = GetTestHandler(HttpStatusCode.OK, returnValue);
            var httpClient = new HttpClient(handlerMock.Object) { BaseAddress = new Uri("http://test.com/") };
            var client = new RabbitMQAdminClient(httpClient, TestConfiguration.UserName, TestConfiguration.Password);

            //Act
            var extensions = await client.GetExtensions(CancellationToken.None);

            //Assert
            var keyValuePairs = extensions.ToList();

            keyValuePairs.Should().NotBeNull();
            keyValuePairs.Should().HaveCountLessOrEqualTo(3);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1),  ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get  && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }
    }
}