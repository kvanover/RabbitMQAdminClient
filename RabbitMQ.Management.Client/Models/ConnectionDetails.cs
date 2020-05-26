using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class ConnectionDetails
    {
        public string Name { get; set; }

        public string PeerHost { get; set; }

        public object PeerPort { get; set; }
    }
}