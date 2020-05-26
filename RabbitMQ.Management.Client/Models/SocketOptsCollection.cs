using System.Collections.Generic;

namespace RabbitMQ.Management.Client.Models
{
    public struct SocketOptsCollection
    {
        
        public List<SocketOpts> SocketOpts;

        public static implicit operator SocketOptsCollection(List<SocketOpts> opts) => new SocketOptsCollection { SocketOpts = opts };
        public static implicit operator SocketOptsCollection(SocketOpts opt) => new SocketOptsCollection { SocketOpts = new List<SocketOpts> { opt } };
    }
}