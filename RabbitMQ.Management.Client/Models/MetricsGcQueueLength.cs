using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class MetricsGcQueueLength
    {
        [JsonPropertyName("connection_closed")]
        public decimal ConnectionClosed { get; set; }

        [JsonPropertyName("channel_closed")]
        public decimal ChannelClosed { get; set; }

        [JsonPropertyName("consumer_deleted")]
        public decimal ConsumerDeleted { get; set; }

        [JsonPropertyName("exchange_deleted")]
        public decimal ExchangeDeleted { get; set; }

        [JsonPropertyName("queue_deleted")]
        public decimal QueueDeleted { get; set; }

        [JsonPropertyName("vhost_deleted")]
        public decimal VhostDeleted { get; set; }

        [JsonPropertyName("node_node_deleted")]
        public decimal NodeNodeDeleted { get; set; }

        [JsonPropertyName("channel_consumer_deleted")]
        public decimal ChannelConsumerDeleted { get; set; }
    }
}