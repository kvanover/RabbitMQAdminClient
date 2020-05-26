using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ChannelDetails
    {
        [JsonPropertyName("connection_name")]
        public string ConnectionName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("number")]
        public decimal Number { get; set; }

        [JsonPropertyName("peer_host")]
        public string PeerHost { get; set; }

        [JsonPropertyName("peer_port")]
        public object PeerPort { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}