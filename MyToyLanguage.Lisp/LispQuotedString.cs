using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	internal class LispQuotedString : LispExpression
	{
		private readonly string _value;

		public override LispExpression Reduce(LispContext context)
		{
			return this;
		}

		public LispQuotedString(string value)
		{
			_value = value;
		}

		public override string ToString()
		{
			return string.Format("\"{0}\"", _value.Replace(@"\", @"\\").Replace(@"""", @"\"""));
		}
	}
}
