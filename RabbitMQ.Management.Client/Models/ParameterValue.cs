using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ParameterValue
    {
        [JsonPropertyName("ack-mode")]
        public string AckMode { get; set; }

        [JsonPropertyName("add-forward-headers")]
        public bool AddForwardHeaders { get; set; }

        [JsonPropertyName("delete-after")]
        public string DeleteAfter { get; set; }

        [JsonPropertyName("dest-exchange")]
        public string DestExchange { get; set; }

        [JsonPropertyName("dest-uri")]
        public string DestUri { get; set; }

        [JsonPropertyName("prefetch-count")]
        public decimal PrefetchCount { get; set; }

        [JsonPropertyName("src-queue")]
        public string SrcQueue { get; set; }

        [JsonPropertyName("src-uri")]
        public string SrcUri { get; set; }
    }
}