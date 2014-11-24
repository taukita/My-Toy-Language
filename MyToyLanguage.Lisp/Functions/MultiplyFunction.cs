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
		public override string Id
		{
			get
			{
				return "*";
			}
		}

		public override LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CannotBeCalledWithFewerThanNArguments(Id, e, 2);
			return new LispAtom(e.Select(a => a.Reduce(context))
			                     .Cast<LispAtom>()
			                     .Select(a => a.ToDecimal())
			                     .Aggregate(1m, (current, d) => current*d)
			                     .ToString(CultureInfo.InvariantCulture));
		}
	}
}
