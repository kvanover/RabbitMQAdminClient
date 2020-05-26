using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class TartuGecko
    {
        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }
    }
}