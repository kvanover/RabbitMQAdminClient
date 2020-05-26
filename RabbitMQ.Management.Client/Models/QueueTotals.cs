using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class QueueTotals
    {
        [JsonPropertyName("messages")]
        public decimal Messages { get; set; }

        [JsonPropertyName("messages_details")]
        public Details MessagesDetails { get; set; }

        [JsonPropertyName("messages_ready")]
        public decimal MessagesReady { get; set; }

        [JsonPropertyName("messages_ready_details")]
        public Details MessagesReadyDetails { get; set; }

        [JsonPropertyName("messages_unacknowledged")]
        public decimal MessagesUnacknowledged { get; set; }

        [JsonPropertyName("messages_unacknowledged_details")]
        public Details MessagesUnacknowledgedDetails { get; set; }
    }
}