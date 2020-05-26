using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Permission
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("vhost")]
        public string Vhost { get; set; }

        [JsonPropertyName("configure")]
        public string Configure { get; set; }

        [JsonPropertyName("write")]
        public string Write { get; set; }

        [JsonPropertyName("read")]
        public string Read { get; set; }
    }
}