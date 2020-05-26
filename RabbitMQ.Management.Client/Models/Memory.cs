using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Memory
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

        [JsonPropertyName("other_proc")]
        public decimal OtherProc { get; set; }

        [JsonPropertyName("metrics")]
        public decimal Metrics { get; set; }

        [JsonPropertyName("mgmt_db")]
        public decimal MgmtDb { get; set; }

        [JsonPropertyName("mnesia")]
        public decimal Mnesia { get; set; }

        [JsonPropertyName("other_ets")]
        public decimal OtherEts { get; set; }

        [JsonPropertyName("binary")]
        public decimal Binary { get; set; }

        [JsonPropertyName("msg_index")]
        public decimal MsgIndex { get; set; }

        [JsonPropertyName("code")]
        public decimal Code { get; set; }

        [JsonPropertyName("atom")]
        public decimal Atom { get; set; }

        [JsonPropertyName("other_system")]
        public decimal OtherSystem { get; set; }

        [JsonPropertyName("allocated_unused")]
        public decimal AllocatedUnused { get; set; }

        [JsonPropertyName("reserved_unallocated")]
        public decimal ReservedUnallocated { get; set; }

        [JsonPropertyName("strategy")]
        public string Strategy { get; set; }

        [JsonPropertyName("total")]
        public MemoryTotal Total { get; set; }
    }
}