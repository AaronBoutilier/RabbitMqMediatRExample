using Example.Domain;
using Example.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Example.RealTimeService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					services.AddSingleton(typeof(IDomainEventConsumer), new DomainEventConsumer("Real Time"));
					services.AddHostedService<Worker>();
				});
	}
}
