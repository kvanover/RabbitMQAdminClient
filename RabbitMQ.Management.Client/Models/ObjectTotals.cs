using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ObjectTotals
    {
        [JsonPropertyName("channels")]
        public decimal Channels { get; set; }

        [JsonPropertyName("connections")]
        public decimal Connections { get; set; }

        [JsonPropertyName("consumers")]
        public decimal Consumers { get; set; }

        [JsonPropertyName("exchanges")]
        public decimal Exchanges { get; set; }

        [JsonPropertyName("queues")]
        public decimal Queues { get; set; }
    }
}