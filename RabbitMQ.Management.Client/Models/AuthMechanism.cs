using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class AuthMechanism
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}