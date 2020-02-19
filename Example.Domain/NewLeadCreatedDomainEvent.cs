namespace Example.Domain
{
	public class NewLeadCreatedDomainEvent : IDomainEvent
	{
		public static string ExchangeName { get; } = "new.leads.exchange";

		public string Id { get; private set; }

		public NewLeadCreatedDomainEvent(string id)
		{
			Id = id;
		}
	}
}
