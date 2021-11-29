using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebMail.Application.Common
{
	public enum ErrorCodes
	{
		SystemError = 100,
		LoginUserNotFound = 101,
		LoginUserBadPassword = 102,
		LoginUserBadCertificate = 103,
	}

	public class CommandResult
	{
		public List<ErrorCodes> ErrorCodes { get; set; }

		public bool HasErrors => ErrorCodes.Any();

		public static CommandResult Success => Create();

		protected CommandResult()
		{
			ErrorCodes = new List<ErrorCodes>();
		}

		public static CommandResult Create() => new CommandResult();

		public CommandResult WithError(ErrorCodes error)
		{
			ErrorCodes.Add(error);
			return this;
		}

		public CommandResult WithErrors(IEnumerable<ErrorCodes> errors)
		{
			ErrorCodes.AddRange(errors);
			return this;
		}
	}

	public class CommandResult<T> : CommandResult
	{
		public T Value { get; set; }

		public CommandResult(T value)
		{
			Value = value;
		}

		public static CommandResult<T> Create(T value)
		{
			return new CommandResult<T>(value);
		}

		public new CommandResult<T> WithError(ErrorCodes error)
		{
			ErrorCodes.Add(error);
			return this;
		}

		public new CommandResult<T> WithErrors(IEnumerable<ErrorCodes> errors)
		{
			ErrorCodes.AddRange(errors);
			return this;
		}

	}
}
