using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class GarbageCollection
    {
        public decimal FullsweepAfter { get; set; }

        public decimal MaxHeapSize { get; set; }

        public decimal MinBinVheapSize { get; set; }

        public decimal MinHeapSize { get; set; }

        public decimal MinorGcs { get; set; }
    }
}