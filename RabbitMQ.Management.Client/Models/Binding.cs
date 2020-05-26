using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Binding
    {
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("vhost")]
        public string Vhost { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("destination_type")]
        public string DestinationType { get; set; }

        [JsonPropertyName("routing_key")]
        public string RoutingKey { get; set; }

        [JsonPropertyName("arguments")]
        public IDictionary<string, object> Arguments { get; set; }
    }
}