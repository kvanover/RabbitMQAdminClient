using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class RabbitMqConnection
    {
        [JsonPropertyName("client_properties")]
        public ClientProperties ClientProperties { get; set; }

        [JsonPropertyName("connected_at")]
        public decimal ConnectedAt { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("user_who_performed_action")]
        public string UserWhoPerformedAction { get; set; }

        [JsonPropertyName("vhost")]
        public string Vhost { get; set; }

        [JsonPropertyName("auth_mechanism")]
        public string AuthMechanism { get; set; }

        [JsonPropertyName("channel_max")]
        public decimal? ChannelMax { get; set; }

        [JsonPropertyName("channels")]
        public decimal? Channels { get; set; }

        [JsonPropertyName("frame_max")]
        public decimal? FrameMax { get; set; }

        [JsonPropertyName("garbage_collection")]
        public GarbageCollection GarbageCollection { get; set; }

        [JsonPropertyName("host")]
        public string Host { get; set; }

        [JsonPropertyName("peer_cert_issuer")]
        public object PeerCertIssuer { get; set; }

        [JsonPropertyName("peer_cert_subject")]
        public object PeerCertSubject { get; set; }

        [JsonPropertyName("peer_cert_validity")]
        public object PeerCertValidity { get; set; }

        [JsonPropertyName("peer_host")]
        public string PeerHost { get; set; }

        [JsonPropertyName("peer_port")]
        public decimal? PeerPort { get; set; }

        [JsonPropertyName("port")]
        public decimal? Port { get; set; }

        [JsonPropertyName("recv_cnt")]
        public decimal? RecvCnt { get; set; }

        [JsonPropertyName("recv_oct")]
        public decimal? RecvOct { get; set; }

        [JsonPropertyName("recv_oct_details")]
        public Details RecvOctDetails { get; set; }

        [JsonPropertyName("reductions")]
        public decimal? Reductions { get; set; }

        [JsonPropertyName("reductions_details")]
        public Details ReductionsDetails { get; set; }

        [JsonPropertyName("send_cnt")]
        public decimal? SendCnt { get; set; }

        [JsonPropertyName("send_oct")]
        public decimal? SendOct { get; set; }

        [JsonPropertyName("send_oct_details")]
        public Details SendOctDetails { get; set; }

        [JsonPropertyName("send_pend")]
        public decimal? SendPend { get; set; }

        [JsonPropertyName("ssl")]
        public bool? Ssl { get; set; }

        [JsonPropertyName("ssl_cipher")]
        public string SslCipher { get; set; }

        [JsonPropertyName("ssl_hash")]
        public string SslHash { get; set; }

        [JsonPropertyName("ssl_key_exchange")]
        public string SslKeyExchange { get; set; }

        [JsonPropertyName("ssl_protocol")]
        public string SslProtocol { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("timeout")]
        public decimal? Timeout { get; set; }
    }
}