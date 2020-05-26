using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class CreateBindingRequest
    {
        [JsonPropertyName("routing_key")]
        public string RoutingKey { get; set; }

        [JsonPropertyName("arguments")]
        public IDictionary<string, object> Arguments { get; set; }
    }
}