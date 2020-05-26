using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class SystemMessageStats
    {
        [JsonPropertyName("disk_reads")]
        public decimal DiskReads { get; set; }

        [JsonPropertyName("disk_reads_details")]
        public Details DiskReadsDetails { get; set; }

        [JsonPropertyName("disk_writes")]
        public decimal DiskWrites { get; set; }

        [JsonPropertyName("disk_writes_details")]
        public Details DiskWritesDetails { get; set; }
    }
}