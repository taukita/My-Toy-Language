using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToyLanguage.Lisp.Functions
{
	internal class LambdaFunction : LispFunction
	{
		public override LispExpression Apply(IEnumerable<LispExpression> expressions, LispContext context)
		{
			var e = expressions as LispExpression[] ?? expressions.ToArray();
			CanBeCalledWithOnlyNArguments(Id, e, 2);
			var arguments = ((LispList) e[0]).Expressions.OfType<LispAtom>().Select(a => a.ToString()).ToArray();
			return new AnonymousFunction(arguments, e[1]);
		}

		public override string Id
		{
			get
			{
				return "lambda";
			}
		}
	}
}
