using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Management.Client;

namespace RabbitClient
{
    class Program
    {
        static async Task<int> Main()
        {
            try
            {
                await MainAsync();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        private static async Task MainAsync()
        {
            var configuration = LoadConfiguration();

            var url = configuration.GetValue<string>("rabbit:url");
            var username = configuration.GetValue<string>("rabbit:username");
            var password = configuration.GetValue<string>("rabbit:password");;

            var httpClient = new HttpClient { BaseAddress = new Uri(url)};

            var client = new RabbitMQAdminClient(httpClient, username, password);

            var queues = await client.GetQueues();
            var exchanges = await client.GetExchanges();
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.local.json", true, true);

            return  builder.Build();
        }
    }
}
