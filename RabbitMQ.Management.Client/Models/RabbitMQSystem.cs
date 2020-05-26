using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class RabbitMqSystem
    {
        [JsonPropertyName("management_version")]
        public string ManagementVersion { get; set; }

        [JsonPropertyName("rates_mode")]
        public string RatesMode { get; set; }

        [JsonPropertyName("sample_retention_policies")]
        public SampleRetentionPolicies SampleRetentionPolicies { get; set; }

        [JsonPropertyName("exchange_types")]
        public List<ExchangeType> ExchangeTypes { get; set; }

        [JsonPropertyName("rabbitmq_version")]
        public string RabbitmqVersion { get; set; }

        [JsonPropertyName("cluster_name")]
        public string ClusterName { get; set; }

        [JsonPropertyName("erlang_version")]
        public string ErlangVersion { get; set; }

        [JsonPropertyName("erlang_full_version")]
        public string ErlangFullVersion { get; set; }

        [JsonPropertyName("message_stats")]
        public SystemMessageStats MessageStats { get; set; }

        [JsonPropertyName("churn_rates")]
        public ChurnRates ChurnRates { get; set; }

        [JsonPropertyName("queue_totals")]
        public QueueTotals QueueTotals { get; set; }

        [JsonPropertyName("object_totals")]
        public ObjectTotals ObjectTotals { get; set; }

        [JsonPropertyName("statistics_db_event_queue")]
        public decimal StatisticsDbEventQueue { get; set; }

        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("listeners")]
        public List<Listener> Listeners { get; set; }

        [JsonPropertyName("contexts")]
        public List<Context> Contexts { get; set; }
    }
}