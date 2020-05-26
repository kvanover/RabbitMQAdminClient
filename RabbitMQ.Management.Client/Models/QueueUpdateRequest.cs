using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class QueueUpdateRequest
    {
        [JsonPropertyName("durable")]
        public bool Durable { get; set; }

        [JsonPropertyName("auto_delete")]
        public bool AutoDelete { get; set; }

        [JsonPropertyName("arguments")]
        public IDictionary<string, object> Arguments { get; set; }
    }
}