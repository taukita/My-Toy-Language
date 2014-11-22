using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Functions
{
	internal class AddFunction : LispFunction
	{
		public override LispExpression Apply(IEnumerable<LispExpression> expressions)
		{
			return new LispAtom(expressions
				                    .Cast<LispAtom>()
				                    .Select(a => a.ToDecimal())
				                    .Sum()
				                    .ToString(CultureInfo.InvariantCulture));
		}
	}
}
