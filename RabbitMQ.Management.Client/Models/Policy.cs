using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Policy
    {
        [JsonPropertyName("vhost")]
        public string Vhost { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }

        [JsonPropertyName("apply-to")]
        public string ApplyTo { get; set; }

        [JsonPropertyName("definition")]
        public Definition Definition { get; set; }

        [JsonPropertyName("priority")]
        public decimal Priority { get; set; }
    }
}