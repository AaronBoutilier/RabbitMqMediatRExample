using System;

namespace Example.Domain
{
	public class Lead
	{
		public StringId Id { get; private set; }
		public NameValueObject Name { get; private set; }

		public Lead(StringId id, NameValueObject name)
		{
			Id = id ?? throw new NullReferenceException("Missing id");
			Name = name ?? throw new NullReferenceException("Missing name");
		}

	}
}
