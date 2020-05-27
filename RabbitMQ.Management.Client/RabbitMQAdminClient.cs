using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Management.Client.Models;

namespace RabbitMQ.Management.Client
{
    public sealed partial class RabbitMQAdminClient
    {
        public async Task<RabbitMqSystem> GetSystemOverview(CancellationToken cancellationToken = default)
        {
            return await Get<RabbitMqSystem>(RabbitMQEndPoints.SystemOverview, cancellationToken);
        }

        public async Task<string> GetClusterName(CancellationToken cancellationToken = default)
        {
            var clusterName = await Get<ClusterName>(RabbitMQEndPoints.GetClusterName, cancellationToken);

            return clusterName?.Name;
        }

        public async Task ChangeClusterName(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            await Put(RabbitMQEndPoints.PutClusterName, new ClusterName { Name = name }, cancellationToken);
        }

        public async Task<IEnumerable<RabbitMqNode>> GetNodes(QueryOrder sorting = QueryOrder.Ascending, Expression<Func<RabbitMqNode, object>> sortSelector = null, PropertyFilters<RabbitMqNode> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(RabbitMQEndPoints.GetAllNodes, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<RabbitMqNode> GetNode(string name, bool memory = false, bool binary = false, CancellationToken cancellationToken = default)
        {
            return await Get<RabbitMqNode>(string.Format(RabbitMQEndPoints.GetNode, name, memory.ToString().ToLowerInvariant(), binary.ToString().ToLowerInvariant()), cancellationToken);
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetExtensions(CancellationToken cancellationToken = default)
        {
            return await Get(RabbitMQEndPoints.GetExtensions, async (stream, token) =>
            {
                var result = new List<KeyValuePair<string, string>>();

                using (var jsonDoc = await JsonDocument.ParseAsync(stream, cancellationToken: token))
                {
                    result.AddRange(from jsonElement in jsonDoc.RootElement.EnumerateArray() from property in jsonElement.EnumerateObject() select new KeyValuePair<string, string>(property.Name, property.Value.GetString()));
                }

                return result;
            }, cancellationToken);
        }

        public async Task<RabbitMqDefinition> GetDefinitions(string virtualHost = null, CancellationToken cancellationToken = default)
        {
            var endPoint = GetEndpointForVHost(RabbitMQEndPoints.GetDefinitions, RabbitMQEndPoints.GetDefinitionsWithVHost, virtualHost);

            return await Get<RabbitMqDefinition>(endPoint, cancellationToken);
        }

        public async Task<IEnumerable<RabbitMqConnection>> GetConnections(string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<RabbitMqConnection, object>> sortSelector = null, PropertyFilters<RabbitMqConnection> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(virtualHost, RabbitMQEndPoints.GetConnections, RabbitMQEndPoints.GetConnectionsWithVHost, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<RabbitMqConnection> GetConnection(string connectionName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionName)) throw new ArgumentNullException(nameof(connectionName));

            return await Get<RabbitMqConnection>(string.Format(RabbitMQEndPoints.GetConnection, connectionName), cancellationToken);
        }

        
        public async Task DeleteConnection(string connectionName, string reason = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionName)) throw new ArgumentNullException(nameof(connectionName));
            
            var headers = new Dictionary<string, IEnumerable<string>>();

            if (!string.IsNullOrEmpty(reason))
            {
                headers.Add("X-Reason", new List<string> { reason});
            }

            await  Delete(string.Format(RabbitMQEndPoints.GetConnection, connectionName), headers, cancellationToken);
        }

        public async Task<IEnumerable<RabbitMqChannel>> GetChannelsForConnection(string connectionName, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<RabbitMqChannel, object>> sortSelector = null, PropertyFilters<RabbitMqChannel> filters = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(connectionName)) throw new ArgumentNullException(nameof(connectionName));

            return await GetList(string.Format(RabbitMQEndPoints.GetChannelsForConnection, connectionName), sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<IEnumerable<RabbitMqChannel>> GetOpenChannels(string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<RabbitMqChannel, object>> sortSelector = null, PropertyFilters<RabbitMqChannel> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(virtualHost, RabbitMQEndPoints.GetOpenChannels, RabbitMQEndPoints.GetOpenChannelsWithVHost, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<RabbitMqChannel> GetChannel(string channelName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(channelName)) throw new ArgumentNullException(nameof(channelName));

            return await Get<RabbitMqChannel>(string.Format(RabbitMQEndPoints.GetChannel, channelName), cancellationToken);
        }

        public async Task<IEnumerable<RabbitMqConsumer>> GetConsumers(string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<RabbitMqConsumer, object>> sortSelector = null, PropertyFilters<RabbitMqConsumer> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(virtualHost, RabbitMQEndPoints.GetConsumers, RabbitMQEndPoints.GetConsumersWithVHost, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<IEnumerable<Exchange>> GetExchanges(string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Exchange, object>> sortSelector = null, PropertyFilters<Exchange> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(virtualHost, RabbitMQEndPoints.GetExchanges, RabbitMQEndPoints.GetExchangesWithVHost, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<Exchange> GetExchange(string exchangeName, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (exchangeName == null) throw new ArgumentNullException(nameof(exchangeName));

            return await Get<Exchange>(string.Format(RabbitMQEndPoints.GetExchange, ConvertVirtualHost(virtualHost), exchangeName), cancellationToken);
        }

        public async Task UpdateExchange(string exchangeName, ExchangeUpdateRequest request, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (exchangeName == null) throw new ArgumentNullException(nameof(exchangeName));
            if (request == null) throw new ArgumentNullException(nameof(request));

            await Put(string.Format(RabbitMQEndPoints.PutExchange, ConvertVirtualHost(virtualHost), exchangeName), request, cancellationToken);
        }

        public async Task DeleteExchange(string exchangeName, bool ifUnused = false, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (exchangeName == null) throw new ArgumentNullException(nameof(exchangeName));

            await  Delete(string.Format(RabbitMQEndPoints.DeleteExchange, ConvertVirtualHost(virtualHost), exchangeName, ifUnused.ToString().ToLower()), null, cancellationToken);
        }

        public async Task<IEnumerable<Binding>> GetExchangeBindings(string exchangeName, ExchangeBindingType type, string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Binding, object>> sortSelector = null, PropertyFilters<Binding> filters = null, CancellationToken cancellationToken = default)
        {
            var uriTemplate= type == ExchangeBindingType.Source ? RabbitMQEndPoints.GetBindingForSourceExchange : RabbitMQEndPoints.GetBindingForDestinationExchange;
            var uri = string.Format(uriTemplate, ConvertVirtualHost(virtualHost), exchangeName);

            return await GetList(uri, sorting, sortSelector, filters, cancellationToken);
        }

        //api/exchanges/vhost/name/publish publish a message is better done with the rabbitMq Client

        public async Task<IEnumerable<Queue>> GetQueues(string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Queue, object>> sortSelector = null, PropertyFilters<Queue> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(virtualHost, RabbitMQEndPoints.GetQueues, RabbitMQEndPoints.GetQueuesWithVHost, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<Queue> GetQueue(string queueName, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));

            return await Get<Queue>(string.Format(RabbitMQEndPoints.GetQueue, ConvertVirtualHost(virtualHost), queueName), cancellationToken);
        }

        public async Task UpdateQueue(string queueName, QueueUpdateRequest request, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));
            if (request == null) throw new ArgumentNullException(nameof(request));

            await Put(string.Format(RabbitMQEndPoints.PutQueue, ConvertVirtualHost(virtualHost), queueName), request, cancellationToken);
        }

        public async Task DeleteQueue(string queueName, bool ifUnused = false, bool ifEmpty = false, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));

            await  Delete(string.Format(RabbitMQEndPoints.DeleteQueue, ConvertVirtualHost(virtualHost), queueName, ifEmpty.ToString().ToLowerInvariant(), ifUnused.ToString().ToLowerInvariant()), null, cancellationToken);
        }

        public async Task<IEnumerable<Binding>> GetQueueBindings(string queueName, string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Binding, object>> sortSelector = null, PropertyFilters<Binding> filters = null, CancellationToken cancellationToken = default)
        {
            var uri = string.Format(RabbitMQEndPoints.GetQueueBindings, ConvertVirtualHost(virtualHost), queueName);

            return await GetList(uri, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task DeleteQueueContent(string queueName, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));

            await  Delete(string.Format(RabbitMQEndPoints.DeleteQueueContents, ConvertVirtualHost(virtualHost), queueName), null, cancellationToken);
        }

        public async Task PostQueueAction(string queueName, string action, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));
            if (action == null) throw new ArgumentNullException(nameof(action));
            if (!action.Equals(QueueAction.Sync) && !action.Equals(QueueAction.CancelSync)) throw new ArgumentOutOfRangeException(nameof(action));
            
            await  Post(string.Format(RabbitMQEndPoints.PostQueueActions, ConvertVirtualHost(virtualHost), queueName), new {action}, cancellationToken);
        }

        // /api/queues/vhost/name/get Get messages from a queue

        public async Task<IEnumerable<Binding>> GetBindings(string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Binding, object>> sortSelector = null, PropertyFilters<Binding> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(virtualHost, RabbitMQEndPoints.GetBindings, RabbitMQEndPoints.GetBindingsWithVHost, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<IEnumerable<Binding>> GetQueueBindings(string exchangeName, string queueName, string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Binding, object>> sortSelector = null, PropertyFilters<Binding> filters = null, CancellationToken cancellationToken = default)
        {
            if (exchangeName == null) throw new ArgumentNullException(nameof(exchangeName));
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));

            return await GetList(string.Format(RabbitMQEndPoints.GetBindingForExchangeAndQueue, ConvertVirtualHost(virtualHost), exchangeName, queueName), sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<string> CreateQueueBinding(CreateBindingRequest request, string exchangeName, string queueName, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (exchangeName == null) throw new ArgumentNullException(nameof(exchangeName));
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));

            var result= await Post(string.Format(RabbitMQEndPoints.PostQueueBinding, ConvertVirtualHost(virtualHost), exchangeName, queueName), request, cancellationToken);

            return result.ContainsKey("Location") ? result["Location"].FirstOrDefault() : string.Empty;
        }

        public async Task<Binding> GetQueueBinding(string exchangeName, string queueName, string propertyKey, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (exchangeName == null) throw new ArgumentNullException(nameof(exchangeName));
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));
            if (propertyKey == null) throw new ArgumentNullException(nameof(propertyKey));

            return await Get<Binding>(string.Format(RabbitMQEndPoints.GetQueueBinding, ConvertVirtualHost(virtualHost), exchangeName, queueName, propertyKey), cancellationToken);
        }

        public async Task DeleteQueueBinding(string exchangeName, string queueName, string propertyKey, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (exchangeName == null) throw new ArgumentNullException(nameof(exchangeName));
            if (queueName == null) throw new ArgumentNullException(nameof(queueName));
            if (propertyKey == null) throw new ArgumentNullException(nameof(propertyKey));

            await Delete(string.Format(RabbitMQEndPoints.DeleteQueueBinding, ConvertVirtualHost(virtualHost), exchangeName, queueName, propertyKey), null, cancellationToken);
        }

        public async Task<IEnumerable<Binding>> GetExchangeBindings(string sourceExchangeName, string destinationExchangeName, string virtualHost = null, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Binding, object>> sortSelector = null, PropertyFilters<Binding> filters = null, CancellationToken cancellationToken = default)
        {
            if (sourceExchangeName == null) throw new ArgumentNullException(nameof(sourceExchangeName));
            if (destinationExchangeName == null) throw new ArgumentNullException(nameof(destinationExchangeName));

            return await GetList(string.Format(RabbitMQEndPoints.GetBindingForExchanges, ConvertVirtualHost(virtualHost), sourceExchangeName, destinationExchangeName), sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<string> CreateExchangeBinding(CreateBindingRequest request, string sourceExchangeName, string destinationExchangeName, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (sourceExchangeName == null) throw new ArgumentNullException(nameof(sourceExchangeName));
            if (destinationExchangeName == null) throw new ArgumentNullException(nameof(destinationExchangeName));

            var result= await Post(string.Format(RabbitMQEndPoints.PostExchangeBinding, ConvertVirtualHost(virtualHost), sourceExchangeName, destinationExchangeName), request, cancellationToken);

            return result.ContainsKey("Location") ? result["Location"].FirstOrDefault() : string.Empty;
        }

        public async Task<Binding> GetExchangeBinding(string sourceExchangeName, string destinationExchangeName, string propertyKey, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (sourceExchangeName == null) throw new ArgumentNullException(nameof(sourceExchangeName));
            if (destinationExchangeName == null) throw new ArgumentNullException(nameof(destinationExchangeName));
            if (propertyKey == null) throw new ArgumentNullException(nameof(propertyKey));

            return await Get<Binding>(string.Format(RabbitMQEndPoints.GetExchangeBinding, ConvertVirtualHost(virtualHost), sourceExchangeName, destinationExchangeName, propertyKey), cancellationToken);
        }

        public async Task DeleteExchangeBinding(string sourceExchangeName, string destinationExchangeName, string propertyKey, string virtualHost = null, CancellationToken cancellationToken = default)
        {
            if (sourceExchangeName == null) throw new ArgumentNullException(nameof(sourceExchangeName));
            if (destinationExchangeName == null) throw new ArgumentNullException(nameof(destinationExchangeName));
            if (propertyKey == null) throw new ArgumentNullException(nameof(propertyKey));

            await Delete(string.Format(RabbitMQEndPoints.DeleteExchangeBinding, ConvertVirtualHost(virtualHost), sourceExchangeName, destinationExchangeName, propertyKey), null, cancellationToken);
        }

        public async Task<IEnumerable<VHost>> GetVirtualHosts(QueryOrder sorting = QueryOrder.Ascending, Expression<Func<VHost, object>> sortSelector = null, PropertyFilters<VHost> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(RabbitMQEndPoints.GetVirtualHosts, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task<VHost> GetVirtualHost(string virtualHost, CancellationToken cancellationToken = default)
        {
            if (virtualHost == null) throw new ArgumentNullException(nameof(virtualHost));

            return await Get<VHost>(string.Format(RabbitMQEndPoints.GetVirtualHost, ConvertVirtualHost(virtualHost)), cancellationToken);
        }

        public async Task UpdateVirtualHost(string virtualHost, string description, IList<string> tags, CancellationToken cancellationToken = default)
        {
            if (virtualHost == null) throw new ArgumentNullException(nameof(virtualHost));
            description ??= string.Empty;
            tags ??= new List<string>();

            await Put(RabbitMQEndPoints.PutVirtualHost, new VirtualHostUpdateRequest { Description = description, Tags = string.Join(",",tags)}, cancellationToken);
        }

        public async Task EnableTracingOnVHost(string virtualHost, CancellationToken cancellationToken = default)
        {
            if (virtualHost == null) throw new ArgumentNullException(nameof(virtualHost));

            await Put(RabbitMQEndPoints.PutVirtualHost, new { tracing = true}, cancellationToken);
        }

        public async Task DisableTracingOnVHost(string virtualHost, CancellationToken cancellationToken = default)
        {
            if (virtualHost == null) throw new ArgumentNullException(nameof(virtualHost));

            await Put(RabbitMQEndPoints.PutVirtualHost, new { tracing = false}, cancellationToken);
        }

        public async Task DeleteVirtualHost(string virtualHost, CancellationToken cancellationToken = default)
        {
            if (virtualHost == null) throw new ArgumentNullException(nameof(virtualHost));

            await Delete(string.Format(RabbitMQEndPoints.DeleteVirtualHost, ConvertVirtualHost(virtualHost)), null, cancellationToken);
        }

        public async Task<IEnumerable<Permission>> GetPermissions(string virtualHost, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<Permission, object>> sortSelector = null, PropertyFilters<Permission> filters = null, CancellationToken cancellationToken = default)
        {
            if (virtualHost == null) throw new ArgumentNullException(nameof(virtualHost));

            return await GetList(string.Format(RabbitMQEndPoints.GetPermissions, ConvertVirtualHost(virtualHost)), sorting, sortSelector, filters, cancellationToken);
        }

        //What is /api/vhosts/name/topic-permissions?
        //What is /api/vhosts/name/start/node?

        public async Task<IEnumerable<User>> GetUsers(QueryOrder sorting = QueryOrder.Ascending, Expression<Func<User, object>> sortSelector = null, PropertyFilters<User> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(RabbitMQEndPoints.GetUsers, sorting, sortSelector, filters, cancellationToken);
        }
        
        public async Task<IEnumerable<User>> GetUsersWithoutPermissions(QueryOrder sorting = QueryOrder.Ascending, Expression<Func<User, object>> sortSelector = null, PropertyFilters<User> filters = null, CancellationToken cancellationToken = default)
        {
            return await GetList(RabbitMQEndPoints.GetUsersWithoutPermissions, sorting, sortSelector, filters, cancellationToken);
        }

        public async Task DeleteUsers(IList<string> users, CancellationToken cancellationToken = default)
        {
            await Post(RabbitMQEndPoints.DeleteUsers, new { users }, cancellationToken);
        }
    }
}
