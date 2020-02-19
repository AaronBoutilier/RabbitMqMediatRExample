using MediatR;

namespace Example.Domain
{
	public class CreateNewLeadCommand : IRequest<string>
	{
		public string Name { get; set; }
	}
}
