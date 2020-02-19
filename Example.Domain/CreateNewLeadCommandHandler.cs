using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Domain
{
	public class CreateNewLeadCommandHandler : IRequestHandler<CreateNewLeadCommand, string>
	{
		private readonly IDomainEventDispatcher _domainEventDispatcher;

		public CreateNewLeadCommandHandler(IDomainEventDispatcher domainEventDispatcher)
		{
			_domainEventDispatcher = domainEventDispatcher;
		}

		public Task<string> Handle(CreateNewLeadCommand request, CancellationToken cancellationToken)
		{
			StringId newId = Guid.NewGuid().ToString();

			Lead newLead = new Lead(newId, request.Name);
			_domainEventDispatcher.Dispatch(new NewLeadCreatedDomainEvent(newId), NewLeadCreatedDomainEvent.ExchangeName);

			return Task.FromResult((string)newLead.Id);
		}
	}
}
