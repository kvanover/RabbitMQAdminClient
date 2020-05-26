using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class RabbitMqConsumer
    {
        [JsonPropertyName("arguments")]
        public Dictionary<string, string> Arguments { get; set; }

        [JsonPropertyName("ack_required")]
        public bool AckRequired { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("activity_status")]
        public string ActivityStatus { get; set; }

        [JsonPropertyName("channel_details")]
        public ChannelDetails ChannelDetails { get; set; }

        [JsonPropertyName("consumer_tag")]
        public string ConsumerTag { get; set; }

        [JsonPropertyName("exclusive")]
        public bool Exclusive { get; set; }

        [JsonPropertyName("prefetch_count")]
        public decimal PrefetchCount { get; set; }

        [JsonPropertyName("queue")]
        public Queue Queue { get; set; }
    }
}