using Example.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Example.RabbitMq
{
	public class DomainEventConsumer : IDomainEventConsumer
	{
		private readonly string _serviceName;
		private readonly IModel _channel;

		public DomainEventConsumer(string serviceName)
		{
			_serviceName = serviceName;
			var factory = new ConnectionFactory() { HostName = "192.168.1.162" };
			var connection = factory.CreateConnection();
			_channel = connection.CreateModel();
		}

		public void ConsumeExchange<DomainEvent>(string exchange, Action<DomainEvent> func) where DomainEvent : IDomainEvent
		{
			_channel.ExchangeDeclare(exchange: exchange, ExchangeType.Fanout, true, false, null);

			var queueName = _channel.QueueDeclare().QueueName;
			_channel.QueueBind(queue: queueName,
							  exchange: exchange,
							  routingKey: "");
			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (model, ea) =>
			{
				var body = ea.Body;
				var message = Encoding.UTF8.GetString(body);
				DomainEvent newLeadCreatedDomainEvent = JsonConvert.DeserializeObject<DomainEvent>(message);

				func(newLeadCreatedDomainEvent);
			};

			_channel.BasicConsume(queue: queueName,
									 autoAck: true,
									 consumer: consumer);
		}
	}
}
