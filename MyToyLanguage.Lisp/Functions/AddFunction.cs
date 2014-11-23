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
		public override LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CannotBeCalledWithZeroArguments("+", e);
			if (e.Length == 1)
			{
				var number = ((LispAtom)e.ElementAt(0).Reduce(context)).ToDecimal();
				return new LispAtom(number.ToString(CultureInfo.InvariantCulture));
			}
			return new LispAtom(e.Select(a => a.Reduce(context))
			                     .Cast<LispAtom>()
			                     .Select(a => a.ToDecimal())
			                     .Sum()
			                     .ToString(CultureInfo.InvariantCulture));
		}
	}
}
