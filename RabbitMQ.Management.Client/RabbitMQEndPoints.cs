namespace RabbitMQ.Management.Client
{
    internal static class RabbitMQEndPoints
    {
        public const string SystemOverview = "api/overview";
        public const string GetClusterName = "api/cluster-name";
        public const string GetAllNodes = "api/nodes";
        public const string GetNode = "api/nodes/{0}?memory={1}&binary={2}";
        public const string GetExtensions = "api/extensions";
        public const string GetDefinitions = "api/definitions";
        public const string GetDefinitionsWithVHost = "api/definitions/{0}";
        public const string GetConnections = "api/connections";
        public const string GetConnectionsWithVHost = "api/vhosts/{0}/connections";
        public const string GetConnection = "api/connections/{0}";
        public const string GetChannelsForConnection = "api/connections/{0}/channels";
        public const string GetOpenChannels = "api/channels";
        public const string GetOpenChannelsWithVHost = "api/vhosts/{0}/channels";
        public const string GetChannel = "api/channels/{0}";
        public const string GetConsumers = "api/consumers";
        public const string GetConsumersWithVHost = "api/consumers/{0}";
        public const string GetExchanges = "api/exchanges";
        public const string GetExchangesWithVHost = "api/exchanges/{0}";
        public const string GetExchange = "api/exchanges/{0}/{1}";
        public const string GetBindingForSourceExchange = "api/exchanges/{0}/{1}/bindings/source";
        public const string GetBindingForDestinationExchange = "api/exchanges/{0}/{1}/bindings/destination";
        public const string GetQueues = "api/queues";
        public const string GetQueuesWithVHost = "api/queues/{0}";
        public const string GetQueue = "api/queues/{0}/{1}";
        public const string GetQueueBindings = "api/queues/{0}/{1}/bindings";
        public const string GetBindings = "api/bindings";
        public const string GetBindingsWithVHost = "api/bindings/{0}";
        public const string GetBindingForExchangeAndQueue = "api/bindings/{0}/e/{1}/q/{2}";
        public const string GetQueueBinding = "api/bindings/{0}/e/{1}/q/{2}/{3}";
        public const string GetBindingForExchanges = "api/bindings/{0}/e/{1}/e/{2}";
        public const string GetExchangeBinding = "api/bindings/{0}/e/{1}/e/{2}/{3}";
        public const string GetVirtualHosts = "api/vhosts";
        public const string GetVirtualHost = "api/vhosts/{0}";
        public const string GetPermissions = "api/vhosts/{0}/permissions";
        public const string GetUsers = "api/users/";
        public const string GetUsersWithoutPermissions = "api/users/without-permissions";


        public const string PostDefinitions = "api/definitions";
        public const string PostDefinitionsWithVHost = "api/definitions/{0}";
        public const string PostMessage = "api/exchanges/{0}/{1}/publish";
        public const string PostQueueActions = "api/queues/{0}/{1}/actions";
        public const string PostQueueBinding = "api/bindings/{0}/e/{1}/q/{2}";
        public const string PostExchangeBinding = "api/bindings/{0}/e/{1}/e/{2}";


        public const string PutClusterName = "api/cluster-name";
        public const string PutExchange = "api/exchanges/{0}/{1}";
        public const string PutQueue = "api/queues/{0}/{1}";
        public const string PutVirtualHost = "/api/vhosts/{0}";

        public const string DeleteExchange = "api/exchanges/{0}/{1}?if-unused={2}";
        public const string DeleteQueue = "api/queues/{0}/{1}?if-empty={2}&if-unused={3}";
        public const string DeleteQueueContents = "api/queues/{0}/{1}/contents";
        public const string DeleteQueueBinding = "api/bindings/{0}/e/{1}/q/{2}/{3}";
        public const string DeleteExchangeBinding = "api/bindings/{0}/e/{1}/e/{2}/{3}";
        public const string DeleteVirtualHost = "api/vhosts/{0}";
        public const string DeleteUsers = "api/users/bulk-delete";
        
    }
}