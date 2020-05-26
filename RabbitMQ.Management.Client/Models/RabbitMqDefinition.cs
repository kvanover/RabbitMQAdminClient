using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class RabbitMqDefinition
    {
        [JsonPropertyName("rabbit_version")]
        public string RabbitVersion { get; set; }

        [JsonPropertyName("users")]
        public List<User> Users { get; set; }

        [JsonPropertyName("vhosts")]
        public List<VHost> Vhosts { get; set; }

        [JsonPropertyName("permissions")]
        public List<Permission> Permissions { get; set; }

        [JsonPropertyName("topic_permissions")]
        public List<object> TopicPermissions { get; set; }

        [JsonPropertyName("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonPropertyName("global_parameters")]
        public List<GlobalParameter> GlobalParameters { get; set; }

        [JsonPropertyName("policies")]
        public List<Policy> Policies { get; set; }

        [JsonPropertyName("queues")]
        public List<Queue> Queues { get; set; }

        [JsonPropertyName("exchanges")]
        public List<Exchange> Exchanges { get; set; }

        [JsonPropertyName("bindings")]
        public List<Binding> Bindings { get; set; }
    }
}