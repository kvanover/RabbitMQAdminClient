using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class Capabilities
    {
        [JsonPropertyName("authentication_failure_close")]
        public bool AuthenticationFailureClose { get; set; }

        [JsonPropertyName("basic.nack")]
        public bool BasicNack { get; set; }

        [JsonPropertyName("connection.blocked")]
        public bool ConnectionBlocked { get; set; }

        [JsonPropertyName("consumer_cancel_notify")]
        public bool ConsumerCancelNotify { get; set; }

        [JsonPropertyName("exchange_exchange_bindings")]
        public bool ExchangeExchangeBindings { get; set; }

        [JsonPropertyName("publisher_confirms")]
        public bool PublisherConfirms { get; set; }
    }
}