using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class SampleRetentionPolicies
    {
        [JsonPropertyName("global")]
        public List<decimal> Global { get; set; }

        [JsonPropertyName("basic")]
        public List<decimal> Basic { get; set; }

        [JsonPropertyName("detailed")]
        public List<decimal> Detailed { get; set; }
    }
}