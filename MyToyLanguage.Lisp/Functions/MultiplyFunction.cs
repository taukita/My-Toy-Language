using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Functions
{
	internal class MultiplyFunction : LispFunction
	{
		public override LispExpression Apply(IEnumerable<LispExpression> expressions)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CannotBeCalledWithFewerThanNArguments("*", e, 2);
			return new LispAtom(e.Cast<LispAtom>()
			                     .Select(a => a.ToDecimal())
			                     .Aggregate(1m, (current, d) => current*d)
			                     .ToString(CultureInfo.InvariantCulture));
		}
	}
}
