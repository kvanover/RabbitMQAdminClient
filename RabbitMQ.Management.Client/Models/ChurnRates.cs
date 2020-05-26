using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ChurnRates
    {
        [JsonPropertyName("channel_closed")]
        public decimal ChannelClosed { get; set; }

        [JsonPropertyName("channel_closed_details")]
        public Details ChannelClosedDetails { get; set; }

        [JsonPropertyName("channel_created")]
        public decimal ChannelCreated { get; set; }

        [JsonPropertyName("channel_created_details")]
        public Details ChannelCreatedDetails { get; set; }

        [JsonPropertyName("connection_closed")]
        public decimal ConnectionClosed { get; set; }

        [JsonPropertyName("connection_closed_details")]
        public Details ConnectionClosedDetails { get; set; }

        [JsonPropertyName("connection_created")]
        public decimal ConnectionCreated { get; set; }

        [JsonPropertyName("connection_created_details")]
        public Details ConnectionCreatedDetails { get; set; }

        [JsonPropertyName("queue_created")]
        public decimal QueueCreated { get; set; }

        [JsonPropertyName("queue_created_details")]
        public Details QueueCreatedDetails { get; set; }

        [JsonPropertyName("queue_declared")]
        public decimal QueueDeclared { get; set; }

        [JsonPropertyName("queue_declared_details")]
        public Details QueueDeclaredDetails { get; set; }

        [JsonPropertyName("queue_deleted")]
        public decimal QueueDeleted { get; set; }

        [JsonPropertyName("queue_deleted_details")]
        public Details QueueDeletedDetails { get; set; }
    }
}