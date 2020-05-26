using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class MemoryTotal
    {
        [JsonPropertyName("erlang")]
        public decimal Erlang { get; set; }

        [JsonPropertyName("rss")]
        public decimal Rss { get; set; }

        [JsonPropertyName("allocated")]
        public decimal Allocated { get; set; }
    }
}