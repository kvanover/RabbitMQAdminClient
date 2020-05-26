using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client
{
    internal class DictionaryToObjectConverter: JsonConverter<IDictionary<string, object>>
    {
        public override IDictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;
            
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Dictionary must be JSON object.");
            
            return ReadDictionary(ref reader);
        }

        public IDictionary<string, object> ReadDictionary(ref Utf8JsonReader reader)
        {
            var result = new Dictionary<string, object>();
            
            while (true)
            {
                if (!reader.Read()) throw new JsonException("Incomplete JSON object");
                
                if (reader.TokenType == JsonTokenType.EndObject)
                    return result;

                var key = reader.GetString();

                if (!reader.Read())
                    throw new JsonException("Incomplete JSON object");

                switch (reader.TokenType)
                {
                    case JsonTokenType.Number:
                        result.Add(key, reader.GetInt64());
                        break;
                    
                    case JsonTokenType.String:
                        result.Add(key, reader.GetString());
                        break;
                    
                    case JsonTokenType.False:
                        result.Add(key, false);
                        break;
                    
                    case JsonTokenType.True:
                        result.Add(key, true);
                        break;
                    
                    case JsonTokenType.StartArray:
                        ReadDictionary(ref reader);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void Write(Utf8JsonWriter writer, IDictionary<string, object> value)
        {
            if (value is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStartObject();

                foreach (var pair in value)
                {
                    writer.WritePropertyName(pair.Key);

                    switch (pair.Value)
                    {
                        case int intValue:
                            writer.WriteNumberValue(intValue);
                            break;
                        
                        case long longValue:
                            writer.WriteNumberValue(longValue);
                            break;

                        case string stringValue:
                            writer.WriteStringValue(stringValue);
                            break;
                        
                        case bool boolValue:
                            writer.WriteBooleanValue(boolValue);
                            break;

                        case IDictionary<string, object> arrayValue:
                            Write(writer, arrayValue);
                            break;
                    }
                }

                writer.WriteEndObject();
            }
        }

        public override void Write(Utf8JsonWriter writer, IDictionary<string, object> value, JsonSerializerOptions options)
        {
            Write(writer, value);
        }
    }
}