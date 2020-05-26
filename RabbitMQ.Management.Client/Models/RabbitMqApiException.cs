using System;

namespace RabbitMQ.Management.Client.Models
{
    public class RabbitMqApiException : Exception
    {
        public int StatusCode { get; set; }

        public string Content { get; set; }
    }
}