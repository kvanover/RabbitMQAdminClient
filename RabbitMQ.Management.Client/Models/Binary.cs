using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Binary
    {
        [JsonPropertyName("connection_readers")]
        public decimal ConnectionReaders { get; set; }

        [JsonPropertyName("connection_writers")]
        public decimal ConnectionWriters { get; set; }

        [JsonPropertyName("connection_channels")]
        public decimal ConnectionChannels { get; set; }

        [JsonPropertyName("connection_other")]
        public decimal ConnectionOther { get; set; }

        [JsonPropertyName("queue_procs")]
        public decimal QueueProcs { get; set; }

        [JsonPropertyName("queue_slave_procs")]
        public decimal QueueSlaveProcs { get; set; }

        [JsonPropertyName("plugins")]
        public decimal Plugins { get; set; }

        [JsonPropertyName("mgmt_db")]
        public decimal MgmtDb { get; set; }

        [JsonPropertyName("msg_index")]
        public decimal MsgIndex { get; set; }

        [JsonPropertyName("other")]
        public decimal Other { get; set; }
    }
}