using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Management.Client.Models;

namespace RabbitMQ.Management.Client
{
    public sealed partial class RabbitMQAdminClient
    {
        private const string Slash = "%2F";

        private readonly HttpClient _client;
        private readonly string _userName;
        private readonly string _password;
        private readonly QueryBuilder _queryBuilder;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
            Converters = { new DictionaryToObjectConverter()}
        };

        public RabbitMQAdminClient(HttpClient client, string userName, string password)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _userName = userName ?? throw new ArgumentNullException(nameof(userName));
            _password = password ?? throw new ArgumentNullException(nameof(password));
            _queryBuilder = new QueryBuilder();

            SetClientDefault(_client);
        }

        private string GetEndpointForVHost(string withoutVHost, string withVHost, string virtualHost)
        {
            return !string.IsNullOrEmpty(virtualHost) ? string.Format(withVHost, ConvertVirtualHost(virtualHost)) : withoutVHost;
        }

        private string ConvertVirtualHost(string virtualHost)
        {
            return virtualHost is null ? Slash : virtualHost == "/" ? Slash : virtualHost;
        }

        private async Task<IEnumerable<T>> GetList<T>(string virtualHost, string uriWithoutVHost, string uriWithVHost, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<T, object>> sortSelector = null, PropertyFilters<T> filters = null, CancellationToken cancellationToken = default)
        {
            var endPoint = GetEndpointForVHost(uriWithoutVHost, uriWithVHost, virtualHost);

            return await GetList(endPoint, sorting, sortSelector, filters, cancellationToken);
        }

        private async Task<IEnumerable<T>> GetList<T>(string endpoint, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<T, object>> sortSelector = null, PropertyFilters<T> filters = null, CancellationToken cancellationToken = default)
        {
            return await Get<List<T>>(_queryBuilder.Build(endpoint, sorting, sortSelector, filters), cancellationToken);
        }

        private async Task<T> Get<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            return await Get(endpoint, async (s, c) => await DeserializeJson<T>(s, c), cancellationToken);
        }

        private async Task<T> Get<T>(string endpoint, Func<Stream, CancellationToken, Task<T>> handleOnSuccess, CancellationToken cancellationToken = default)
        {
            if (endpoint == null) throw new ArgumentNullException(nameof(endpoint));
            if (handleOnSuccess == null) throw new ArgumentNullException(nameof(handleOnSuccess));

            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {
                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return await handleOnSuccess(stream, cancellationToken);
                    }

                    var content = await StreamToString(stream);

                    throw new RabbitMqApiException
                    {
                        StatusCode = (int)response.StatusCode,
                        Content = content
                    };
                }
            }
        }

        private async Task<IDictionary<string, IEnumerable<string>>> Post<TBody>(string endpoint, TBody body, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                var json = JsonSerializer.Serialize(body);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        var content = await StreamToString(stream);

                        throw new RabbitMqApiException
                        {
                            StatusCode = (int)response.StatusCode,
                            Content = content
                        };
                    }

                    return response.Headers.ToDictionary(x => x.Key, x => x.Value);
                }
            }

        }

        private async Task Put<TBody>(string endpoint, TBody body, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Put, endpoint))
            {
                var json = JsonSerializer.Serialize(body);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        var content = await StreamToString(stream);

                        throw new RabbitMqApiException
                        {
                            StatusCode = (int)response.StatusCode,
                            Content = content
                        };
                    }
                }
            }

        }

        private async Task Delete(string endpoint, IDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken = default)
        {

            using (var request = new HttpRequestMessage(HttpMethod.Delete, endpoint))
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
                
                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        var content = await StreamToString(stream);

                        throw new RabbitMqApiException
                        {
                            StatusCode = (int)response.StatusCode,
                            Content = content
                        };
                    }
                }
            }
        }

        private void SetClientDefault(HttpClient client)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{_userName}:{_password}");
            var authenticationValue = Convert.ToBase64String(byteArray);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authenticationValue);
        }
        private static async Task<string> StreamToString(Stream stream)
        {
            if (stream == null) return null;

            using (var sr = new StreamReader(stream))
            {
                return await sr.ReadToEndAsync();
            }
        }

        private async Task<T> DeserializeJson<T>(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream == null || stream.CanRead == false) return default;

            return await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions, cancellationToken);
        }
    }
}
