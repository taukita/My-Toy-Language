using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Functions
{
	internal class SubtractFunction : LispFunction
	{
		public override string Id
		{
			get
			{
				return "-";
			}
		}

		public override LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CannotBeCalledWithZeroArguments(Id, e);
			if (e.Length == 1)
			{
				var number = ((LispAtom)e.ElementAt(0).Reduce(context)).ToDecimal();
				return new LispAtom((-number).ToString(CultureInfo.InvariantCulture));
			}
			var result = ((LispAtom)e.ElementAt(0).Reduce(context)).ToDecimal();
			result = e.Skip(1)
			          .Select(a => a.Reduce(context))
			          .Cast<LispAtom>()
			          .Select(a => a.ToDecimal())
			          .Aggregate(result, (current, d) => current - d);
			return new LispAtom(result.ToString(CultureInfo.InvariantCulture));
		}
	}
}
