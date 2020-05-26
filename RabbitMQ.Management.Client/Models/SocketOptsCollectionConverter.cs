using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client.Models
{
    internal class SocketOptsCollectionConverter : JsonConverter<SocketOptsCollection>
    {
        public override bool CanConvert(Type t) => t == typeof(SocketOptsCollection) || t == typeof(SocketOptsCollection?);

        public override SocketOptsCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.StartObject:
                    var objectValue = JsonSerializer.Deserialize<SocketOpts>(ref reader, options);
                    return new SocketOptsCollection { SocketOpts = new List<SocketOpts> { objectValue } };

                case JsonTokenType.StartArray:
                    var arrayValue = JsonSerializer.Deserialize<List<SocketOpts>>(ref reader, options);
                    return new SocketOptsCollection { SocketOpts = arrayValue };

                default:
                    return new SocketOptsCollection { SocketOpts = new List<SocketOpts>() };
            }
        }

        public override void Write(Utf8JsonWriter writer, SocketOptsCollection value, JsonSerializerOptions options)
        {
            if (value.SocketOpts.Count == 1)
            {
                //write single object
            }
            else
            {
                //write array
            }
        }
    }
}