using CSharpFunctionalExtensions;

namespace Example.Domain
{
	public class NameValueObject
	{
		public string Value { get; private set; }

		private NameValueObject(string value)
		{
			Value = value;
		}

		public static Result<NameValueObject> Create(string name)
		{
			string val = (name ?? string.Empty).Trim();

			if (string.IsNullOrEmpty(val)) return Result.Failure<NameValueObject>("Name is required.");

			return Result.Success(new NameValueObject(val));
		}

		public static implicit operator string(NameValueObject nameValueObject) => nameValueObject.Value;
		public static implicit operator NameValueObject(string name) => Create(name).Value;
	}
}
