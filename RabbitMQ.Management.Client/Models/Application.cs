using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Application
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}