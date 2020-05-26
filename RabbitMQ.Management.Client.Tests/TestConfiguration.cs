using System;

namespace RabbitMQ.Management.Client.Tests
{
    public static class TestConfiguration
    {
        public static readonly Uri Uri = new Uri("http://127.0.0.1:15672/");

        public const string UserName = "guest";

        public const string Password = "guest";
    }
}