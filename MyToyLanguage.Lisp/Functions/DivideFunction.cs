using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Functions
{
	internal class DivideFunction : LispFunction
	{
		public override LispExpression Apply(IEnumerable<LispExpression> expressions)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CannotBeCalledWithFewerThanNArguments("/", e, 2);
			var result = ((LispAtom)e.ElementAt(0)).ToDecimal();
			result = e.Skip(1).Cast<LispAtom>().Select(a => a.ToDecimal()).Aggregate(result, (current, d) => current/d);
			return new LispAtom(result.ToString(CultureInfo.InvariantCulture));
		}
	}
}
