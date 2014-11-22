using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	class FunctionArityException : Exception
	{
		public FunctionArityException()
		{
		}

		public FunctionArityException(string message) : base(message)
		{
		}

		public FunctionArityException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FunctionArityException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
