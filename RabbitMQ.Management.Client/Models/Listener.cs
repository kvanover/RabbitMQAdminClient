using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Listener
    {
        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("port")]
        public decimal Port { get; set; }

        [JsonPropertyName("socket_opts")]
        [JsonConverter(typeof(SocketOptsCollectionConverter))]
        public SocketOptsCollection SocketOpts { get; set; }
    }
}