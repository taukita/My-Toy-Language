using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp
{
	public class LispAtom : LispExpression
	{
		private readonly string _value;

		public LispAtom(string value)
		{
			_value = value;
		}

		public override string ToString()
		{
			return _value;
		}
	}
}
