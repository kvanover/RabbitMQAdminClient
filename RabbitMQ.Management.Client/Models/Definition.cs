using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Definition
    {
        [JsonPropertyName("ha-mode")]
        public string HaMode { get; set; }

        [JsonPropertyName("ha-sync-batch-size")]
        public decimal? HaSyncBatchSize { get; set; }

        [JsonPropertyName("ha-sync-mode")]
        public string HaSyncMode { get; set; }

        [JsonPropertyName("queue-mode")]
        public string QueueMode { get; set; }

        [JsonPropertyName("expires")]
        public decimal? Expires { get; set; }

        [JsonPropertyName("max-length")]
        public decimal? MaxLength { get; set; }

        [JsonPropertyName("message-ttl")]
        public decimal? MessageTtl { get; set; }
    }
}