using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using FluentAssertions;
using Xunit;

namespace RabbitMQ.Management.Client.Tests
{
    public class WhenUsingTheManagementClient
    {
        [Theory]
        [ClassData(typeof(ConstructorTestData))]
        public void ShouldThrowWhenParametersAreNull(string userName, string password)
        {
            var httpClient = new HttpClient { BaseAddress = TestConfiguration.Uri };
            var constructorToTest = new Action(() =>
            {
                var rabbitMqAdminClient = new RabbitMQAdminClient(httpClient, userName, password);
            });

            constructorToTest.Should().Throw<ArgumentNullException>();
        }

        public class ConstructorTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {null, "guest"};
                yield return new object[] { "guest", null};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
