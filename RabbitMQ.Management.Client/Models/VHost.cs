using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class VHost
    {
        [JsonPropertyName("cluster_state")]
        public IDictionary<string, string> ClusterState { get; set; }

        [JsonPropertyName("message_stats")]
        public MessageStats MessageStats { get; set; }

        [JsonPropertyName("messages")]
        public long Messages { get; set; }

        [JsonPropertyName("messages_details")]
        public Details MessagesDetails { get; set; }

        [JsonPropertyName("messages_ready")]
        public long MessagesReady { get; set; }

        [JsonPropertyName("messages_ready_details")]
        public Details MessagesReadyDetails { get; set; }

        [JsonPropertyName("messages_unacknowledged")]
        public long MessagesUnacknowledged { get; set; }

        [JsonPropertyName("messages_unacknowledged_details")]
        public Details MessagesUnacknowledgedDetails { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tracing")]
        public bool Tracing { get; set; }

        [JsonPropertyName("recv_oct")]
        public long? RecvOct { get; set; }

        [JsonPropertyName("recv_oct_details")]
        public Details RecvOctDetails { get; set; }

        [JsonPropertyName("send_oct")]
        public long? SendOct { get; set; }

        [JsonPropertyName("send_oct_details")]
        public Details SendOctDetails { get; set; }
    }
}