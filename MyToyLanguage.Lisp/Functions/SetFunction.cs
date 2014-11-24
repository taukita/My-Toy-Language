using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Functions
{
	internal class SetFunction : LispFunction
	{
		public override string Id
		{
			get
			{
				return "set";
			}
		}

		public override LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CanBeCalledWithOnlyNArguments(Id, e, 2);
			var id = e[0].ToString();
			var value = e[1].Reduce(context);
			context[id] = value;
			return value;
		}
	}
}
