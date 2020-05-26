using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Context
    {
        [JsonPropertyName("ssl_opts")]
        public List<object> SslOpts { get; set; }

        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("cowboy_opts")]
        public string CowboyOpts { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }
    }
}