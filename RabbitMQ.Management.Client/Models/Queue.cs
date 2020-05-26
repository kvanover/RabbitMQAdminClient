using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Queue
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("vhost")]
        public string Vhost { get; set; }

        [JsonPropertyName("durable")]
        public bool Durable { get; set; }

        [JsonPropertyName("auto_delete")]
        public bool AutoDelete { get; set; }

        [JsonPropertyName("arguments")]
        public IDictionary<string, object> Arguments { get; set; }
    }
}