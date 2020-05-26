using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Parameter
    {
        [JsonPropertyName("value")]
        public ParameterValue Value { get; set; }

        [JsonPropertyName("vhost")]
        public string Vhost { get; set; }

        [JsonPropertyName("component")]
        public string Component { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}