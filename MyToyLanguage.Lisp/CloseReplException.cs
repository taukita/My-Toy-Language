using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	public class CloseReplException : Exception
	{
		public CloseReplException()
		{
		}

		public CloseReplException(string message) : base(message)
		{
		}

		public CloseReplException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected CloseReplException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
