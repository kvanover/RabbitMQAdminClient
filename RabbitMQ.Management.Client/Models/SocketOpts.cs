using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class SocketOpts
    {
        [JsonPropertyName("backlog")]
        public decimal? Backlog { get; set; }

        [JsonPropertyName("nodelay")]
        public bool? Nodelay { get; set; }

        [JsonPropertyName("linger")]
        public List<object> Linger { get; set; }

        [JsonPropertyName("exit_on_close")]
        public bool? ExitOnClose { get; set; }
    }
}