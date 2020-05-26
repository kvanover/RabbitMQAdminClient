using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("password_hash")]
        public string PasswordHash { get; set; }

        [JsonPropertyName("hashing_algorithm")]
        public string HashingAlgorithm { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }
    }
}