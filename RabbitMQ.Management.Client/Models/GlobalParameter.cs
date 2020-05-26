using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class GlobalParameter
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}