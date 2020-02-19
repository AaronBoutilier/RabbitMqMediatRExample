using Example.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Example.LoggingService
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private IDomainEventConsumer _consumer;

		public Worker(ILogger<Worker> logger, IDomainEventConsumer consumer)
		{
			_logger = logger;
			_consumer = consumer;

		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_consumer.ConsumeExchange(NewLeadCreatedDomainEvent.ExchangeName, (NewLeadCreatedDomainEvent @event) =>
			{
				_logger.LogInformation(string.Format("[Logging Service] {0} received: {1}", typeof(NewLeadCreatedDomainEvent).Name, @event.Id));
			});

			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
