using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ExchangeUpdateRequest
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("durable")]
        public bool Durable { get; set; }

        [JsonPropertyName("auto_delete")]
        public bool AutoDelete { get; set; }

        [JsonPropertyName("internal")]
        public bool Internal { get; set; }

        [JsonPropertyName("arguments")]
        public IDictionary<string, object> Arguments { get; set; }
    }
}