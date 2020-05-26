
namespace RabbitMQ.Management.Client.Models
{
    public class RabbitMqChannel
    {
        public long AcksUncommitted { get; set; }

        public bool Confirm { get; set; }

        public ConnectionDetails ConnectionDetails { get; set; }

        public long ConsumerCount { get; set; }

        public GarbageCollection GarbageCollection { get; set; }

        public long GlobalPrefetchCount { get; set; }

        public string IdleSince { get; set; }

        public ChannelMessageStats MessageStats { get; set; }

        public long MessagesUnacknowledged { get; set; }

        public long MessagesUncommitted { get; set; }

        public long MessagesUnconfirmed { get; set; }

        public string Name { get; set; }

        public string Node { get; set; }

        public long Number { get; set; }

        public long PendingRaftCommands { get; set; }

        public long PrefetchCount { get; set; }

        public long Reductions { get; set; }

        public Details ReductionsDetails { get; set; }

        public string State { get; set; }

        public bool Transactional { get; set; }

        public string User { get; set; }

        public string UserWhoPerformedAction { get; set; }

        public string Vhost { get; set; }
    }
}