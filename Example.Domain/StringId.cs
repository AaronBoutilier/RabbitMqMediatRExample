using CSharpFunctionalExtensions;

namespace Example.Domain
{
	public class StringId
	{
		public string Value { get; private set; }

		private StringId(string value)
		{
			Value = value;
		}

		public static Result<StringId> Create(string name)
		{
			string val = (name ?? string.Empty).Trim();

			if (string.IsNullOrEmpty(val)) return Result.Failure<StringId>("String Id is required.");

			return Result.Success(new StringId(val));
		}

		public static implicit operator string(StringId nameValueObject) => nameValueObject.Value;
		public static implicit operator StringId(string name) => Create(name).Value;
	}
}
