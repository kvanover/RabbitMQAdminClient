using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ClusterName
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}