using Example.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace Example.RabbitMq
{
	public class DomainEventDispatcher : IDomainEventDispatcher
	{
		private readonly IModel _channel;

		public DomainEventDispatcher()
		{
			var factory = new ConnectionFactory() { HostName = "192.168.1.162" };
			var connection = factory.CreateConnection();
			_channel = connection.CreateModel();
		}

		public Task Dispatch(IDomainEvent @event, string exchangeName)
		{
			_channel.ExchangeDeclare(exchangeName, "fanout", true, false, null);
			_channel.BasicPublish(exchange: exchangeName,
								 routingKey: "",
								 basicProperties: null,
								 body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event)));
			return Task.CompletedTask;
		}
	}
}
