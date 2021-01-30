using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace QuotesWS
{
    public class QuoteDeleteWorker : BackgroundService
    {
        private readonly ILogger<QuoteDeleteWorker> _logger;

        private static readonly HttpClient client = new HttpClient();

        public QuoteDeleteWorker(ILogger<QuoteDeleteWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var stringTask = client.DeleteAsync("https://localhost:44316/api/quotes/clear");
                var msg = await stringTask;
                Console.Write(msg);

                await Task.Delay(5 * 60 * 1000, stoppingToken);
            }
        }
    }
}
