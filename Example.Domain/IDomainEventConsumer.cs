using System;

namespace Example.Domain
{
	public interface IDomainEventConsumer
	{
		void ConsumeExchange<DomainEvent>(string exchange, Action<DomainEvent> func) where DomainEvent : IDomainEvent;
	}
}
