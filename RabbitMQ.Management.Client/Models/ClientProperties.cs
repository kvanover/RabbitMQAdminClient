using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ClientProperties
    {
        [JsonPropertyName("connection_name")]
        public string ConnectionName { get; set; }

        [JsonPropertyName("capabilities")]
        public Capabilities Capabilities { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("information")]
        public string Information { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}