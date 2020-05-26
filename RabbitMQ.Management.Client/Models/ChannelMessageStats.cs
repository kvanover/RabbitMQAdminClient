
namespace RabbitMQ.Management.Client.Models
{
    public class ChannelMessageStats
    {
        public long? Ack { get; set; }

        public Details AckDetails { get; set; }

        public long? Deliver { get; set; }

        public Details DeliverDetails { get; set; }

        public long? DeliverGet { get; set; }

        public Details DeliverGetDetails { get; set; }

        public long? DeliverNoAck { get; set; }

        public Details DeliverNoAckDetails { get; set; }

        public long? Get { get; set; }

        public Details GetDetails { get; set; }

        public long? GetEmpty { get; set; }

        public Details GetEmptyDetails { get; set; }

        public long? GetNoAck { get; set; }

        public Details GetNoAckDetails { get; set; }

        public long? Redeliver { get; set; }

        public Details RedeliverDetails { get; set; }

        public long? Confirm { get; set; }

        public Details ConfirmDetails { get; set; }

        public long? DropUnroutable { get; set; }

        public Details DropUnroutableDetails { get; set; }

        public long? Publish { get; set; }

        public Details PublishDetails { get; set; }

        public long? ReturnUnroutable { get; set; }

        public Details ReturnUnroutableDetails { get; set; }
    }
}