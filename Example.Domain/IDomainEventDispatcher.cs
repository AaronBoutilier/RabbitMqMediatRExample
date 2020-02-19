using System.Threading.Tasks;

namespace Example.Domain
{
	public interface IDomainEventDispatcher
	{
		Task Dispatch(IDomainEvent @event, string queueName);
	}
}
