using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class RabbitMqNode
    {

        [JsonPropertyName("partitions")]
        public List<object> Partitions { get; set; }

        [JsonPropertyName("os_pid")]
        public string OsPid { get; set; }

        [JsonPropertyName("fd_total")]
        public decimal FdTotal { get; set; }

        [JsonPropertyName("sockets_total")]
        public decimal SocketsTotal { get; set; }

        [JsonPropertyName("mem_limit")]
        public decimal MemLimit { get; set; }

        [JsonPropertyName("mem_alarm")]
        public bool MemAlarm { get; set; }

        [JsonPropertyName("disk_free_limit")]
        public decimal DiskFreeLimit { get; set; }

        [JsonPropertyName("disk_free_alarm")]
        public bool DiskFreeAlarm { get; set; }

        [JsonPropertyName("proc_total")]
        public decimal ProcTotal { get; set; }

        [JsonPropertyName("rates_mode")]
        public string RatesMode { get; set; }

        [JsonPropertyName("uptime")]
        public decimal Uptime { get; set; }

        [JsonPropertyName("run_queue")]
        public decimal RunQueue { get; set; }

        [JsonPropertyName("processors")]
        public decimal Processors { get; set; }

        [JsonPropertyName("exchange_types")]
        public List<AuthMechanism> ExchangeTypes { get; set; }

        [JsonPropertyName("auth_mechanisms")]
        public List<AuthMechanism> AuthMechanisms { get; set; }

        [JsonPropertyName("applications")]
        public List<Application> Applications { get; set; }

        [JsonPropertyName("contexts")]
        public List<Context> Contexts { get; set; }

        [JsonPropertyName("log_files")]
        public List<string> LogFiles { get; set; }

        [JsonPropertyName("db_dir")]
        public string DbDir { get; set; }

        [JsonPropertyName("config_files")]
        public List<string> ConfigFiles { get; set; }

        [JsonPropertyName("net_ticktime")]
        public decimal NetTicktime { get; set; }

        [JsonPropertyName("enabled_plugins")]
        public List<string> EnabledPlugins { get; set; }

        [JsonPropertyName("mem_calculation_strategy")]
        public string MemCalculationStrategy { get; set; }

        [JsonPropertyName("ra_open_file_metrics")]
        public RaOpenFileMetrics RaOpenFileMetrics { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("running")]
        public bool Running { get; set; }

        [JsonPropertyName("mem_used")]
        public decimal MemUsed { get; set; }

        [JsonPropertyName("mem_used_details")]
        public Details MemUsedDetails { get; set; }

        [JsonPropertyName("fd_used")]
        public decimal FdUsed { get; set; }

        [JsonPropertyName("fd_used_details")]
        public Details FdUsedDetails { get; set; }

        [JsonPropertyName("sockets_used")]
        public decimal SocketsUsed { get; set; }

        [JsonPropertyName("sockets_used_details")]
        public Details SocketsUsedDetails { get; set; }

        [JsonPropertyName("proc_used")]
        public decimal ProcUsed { get; set; }

        [JsonPropertyName("proc_used_details")]
        public Details ProcUsedDetails { get; set; }

        [JsonPropertyName("disk_free")]
        public decimal DiskFree { get; set; }

        [JsonPropertyName("disk_free_details")]
        public Details DiskFreeDetails { get; set; }

        [JsonPropertyName("gc_num")]
        public decimal GcNum { get; set; }

        [JsonPropertyName("gc_num_details")]
        public Details GcNumDetails { get; set; }

        [JsonPropertyName("gc_bytes_reclaimed")]
        public decimal GcBytesReclaimed { get; set; }

        [JsonPropertyName("gc_bytes_reclaimed_details")]
        public Details GcBytesReclaimedDetails { get; set; }

        [JsonPropertyName("context_switches")]
        public decimal ContextSwitches { get; set; }

        [JsonPropertyName("context_switches_details")]
        public Details ContextSwitchesDetails { get; set; }

        [JsonPropertyName("io_read_count")]
        public decimal IoReadCount { get; set; }

        [JsonPropertyName("io_read_count_details")]
        public Details IoReadCountDetails { get; set; }

        [JsonPropertyName("io_read_bytes")]
        public decimal IoReadBytes { get; set; }

        [JsonPropertyName("io_read_bytes_details")]
        public Details IoReadBytesDetails { get; set; }

        [JsonPropertyName("io_read_avg_time")]
        public double IoReadAvgTime { get; set; }

        [JsonPropertyName("io_read_avg_time_details")]
        public Details IoReadAvgTimeDetails { get; set; }

        [JsonPropertyName("io_write_count")]
        public decimal IoWriteCount { get; set; }

        [JsonPropertyName("io_write_count_details")]
        public Details IoWriteCountDetails { get; set; }

        [JsonPropertyName("io_write_bytes")]
        public decimal IoWriteBytes { get; set; }

        [JsonPropertyName("io_write_bytes_details")]
        public Details IoWriteBytesDetails { get; set; }

        [JsonPropertyName("io_write_avg_time")]
        public decimal IoWriteAvgTime { get; set; }

        [JsonPropertyName("io_write_avg_time_details")]
        public Details IoWriteAvgTimeDetails { get; set; }

        [JsonPropertyName("io_sync_count")]
        public decimal IoSyncCount { get; set; }

        [JsonPropertyName("io_sync_count_details")]
        public Details IoSyncCountDetails { get; set; }

        [JsonPropertyName("io_sync_avg_time")]
        public decimal IoSyncAvgTime { get; set; }

        [JsonPropertyName("io_sync_avg_time_details")]
        public Details IoSyncAvgTimeDetails { get; set; }

        [JsonPropertyName("io_seek_count")]
        public decimal IoSeekCount { get; set; }

        [JsonPropertyName("io_seek_count_details")]
        public Details IoSeekCountDetails { get; set; }

        [JsonPropertyName("io_seek_avg_time")]
        public decimal IoSeekAvgTime { get; set; }

        [JsonPropertyName("io_seek_avg_time_details")]
        public Details IoSeekAvgTimeDetails { get; set; }

        [JsonPropertyName("io_reopen_count")]
        public decimal IoReopenCount { get; set; }

        [JsonPropertyName("io_reopen_count_details")]
        public Details IoReopenCountDetails { get; set; }

        [JsonPropertyName("mnesia_ram_tx_count")]
        public decimal MnesiaRamTxCount { get; set; }

        [JsonPropertyName("mnesia_ram_tx_count_details")]
        public Details MnesiaRamTxCountDetails { get; set; }

        [JsonPropertyName("mnesia_disk_tx_count")]
        public decimal MnesiaDiskTxCount { get; set; }

        [JsonPropertyName("mnesia_disk_tx_count_details")]
        public Details MnesiaDiskTxCountDetails { get; set; }

        [JsonPropertyName("msg_store_read_count")]
        public decimal MsgStoreReadCount { get; set; }

        [JsonPropertyName("msg_store_read_count_details")]
        public Details MsgStoreReadCountDetails { get; set; }

        [JsonPropertyName("msg_store_write_count")]
        public decimal MsgStoreWriteCount { get; set; }

        [JsonPropertyName("msg_store_write_count_details")]
        public Details MsgStoreWriteCountDetails { get; set; }

        [JsonPropertyName("queue_index_journal_write_count")]
        public decimal QueueIndexJournalWriteCount { get; set; }

        [JsonPropertyName("queue_index_journal_write_count_details")]
        public Details QueueIndexJournalWriteCountDetails { get; set; }

        [JsonPropertyName("queue_index_write_count")]
        public decimal QueueIndexWriteCount { get; set; }

        [JsonPropertyName("queue_index_write_count_details")]
        public Details QueueIndexWriteCountDetails { get; set; }

        [JsonPropertyName("queue_index_read_count")]
        public decimal QueueIndexReadCount { get; set; }

        [JsonPropertyName("queue_index_read_count_details")]
        public Details QueueIndexReadCountDetails { get; set; }

        [JsonPropertyName("io_file_handle_open_attempt_count")]
        public decimal IoFileHandleOpenAttemptCount { get; set; }

        [JsonPropertyName("io_file_handle_open_attempt_count_details")]
        public Details IoFileHandleOpenAttemptCountDetails { get; set; }

        [JsonPropertyName("io_file_handle_open_attempt_avg_time")]
        public double IoFileHandleOpenAttemptAvgTime { get; set; }

        [JsonPropertyName("io_file_handle_open_attempt_avg_time_details")]
        public Details IoFileHandleOpenAttemptAvgTimeDetails { get; set; }

        [JsonPropertyName("connection_created")]
        public decimal ConnectionCreated { get; set; }

        [JsonPropertyName("connection_created_details")]
        public Details ConnectionCreatedDetails { get; set; }

        [JsonPropertyName("connection_closed")]
        public decimal ConnectionClosed { get; set; }

        [JsonPropertyName("connection_closed_details")]
        public Details ConnectionClosedDetails { get; set; }

        [JsonPropertyName("channel_created")]
        public decimal ChannelCreated { get; set; }

        [JsonPropertyName("channel_created_details")]
        public Details ChannelCreatedDetails { get; set; }

        [JsonPropertyName("channel_closed")]
        public decimal ChannelClosed { get; set; }

        [JsonPropertyName("channel_closed_details")]
        public Details ChannelClosedDetails { get; set; }

        [JsonPropertyName("queue_declared")]
        public decimal QueueDeclared { get; set; }

        [JsonPropertyName("queue_declared_details")]
        public Details QueueDeclaredDetails { get; set; }

        [JsonPropertyName("queue_created")]
        public decimal QueueCreated { get; set; }

        [JsonPropertyName("queue_created_details")]
        public Details QueueCreatedDetails { get; set; }

        [JsonPropertyName("queue_deleted")]
        public decimal QueueDeleted { get; set; }

        [JsonPropertyName("queue_deleted_details")]
        public Details QueueDeletedDetails { get; set; }

        [JsonPropertyName("cluster_links")]
        public List<object> ClusterLinks { get; set; }

        [JsonPropertyName("metrics_gc_queue_length")]
        public MetricsGcQueueLength MetricsGcQueueLength { get; set; }
    }

    public class RaOpenFileMetrics
    {
        [JsonPropertyName("ra_log_wal")]
        public decimal RaLogWal { get; set; }

        [JsonPropertyName("ra_log_segment_writer")]
        public decimal RaLogSegmentWriter { get; set; }
    }

}